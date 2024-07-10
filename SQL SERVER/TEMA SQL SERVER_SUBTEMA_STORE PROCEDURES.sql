/*1. Crear un store procedureCodigoAscii que imprima los caracteres con su respectivo código ascii en decimal. 
Solo para los caracteres cuyo código sea mayor a 32*/
use master
Drop PROCEDURE sp_PrintAsciiCodes

CREATE Or ALTER PROCEDURE sp_CodigoAciiCodes
AS
BEGIN
    DECLARE @i INT = 32;
    DECLARE @char_str NVARCHAR(1);
    
    WHILE @i <= 255  -- Iteramos desde el código ASCII 0 hasta 255
    BEGIN
        SET @char_str = CHAR(@i);
        PRINT  @char_str + ' (>) ASCII: ' + CAST(@i AS VARCHAR(5));
        SET @i = @i + 1;
    END;
END;


EXEC sp_CodigoAciiCodes

/*2. Crear el store procedure Factorial que reciba como parámetro un número entero 
y que devuelve el factorial calculado en un parámetro de salida*/

CREATE OR ALTER PROCEDURE EjecutarFactorial
    @Numero INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FactorialResultado BIGINT;

    -- Llamada a la función factorial
    SET @FactorialResultado = dbo.factorialProc(@Numero);

    -- Mostrar el resultado (o hacer algo con él)
    SELECT @FactorialResultado AS FactorialResultado;
END;

EXEC EjecutarFactorial @Numero = 5;



/*3. Crear las siguientes Tablas*/
use BancoTich

CREATE TABLE Saldos(
id int identity(1,1) primary key not null,
nombre varchar(50),
saldo int)
----- 
CREATE TABLE Transacciones(
id int identity(1,1) primary key not null,
id_Origen int not null,
id_Destino int not null,
monto decimal(10,2)
CONSTRAINT fkid_Origen FOREIGN KEY(id_Origen)
REFERENCES Saldos (id),
CONSTRAINT id_Destino FOREIGN KEY(id_Destino)
REFERENCES Saldos (id))

 


/*4. Crear un store procedure “Transacciones” que recibirá como parámetros el id de la cuenta de origen, 
el id de la cuenta destino y el monto de la transacción. 
Se deberá crear dentro de una transacción a fin de que los saldos de las cuentas involucradas 
y la tabla de transacciones quede perfectamente consistente.*/

CREATE OR ALTER PROCEDURE TransaccionesId
    @idOrigen INT,
    @idDestino INT,
    @Cantidad DECIMAL(18, 2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar saldo suficiente en la cuenta origen
        DECLARE @SaldoOrigen DECIMAL(18, 2);
        SELECT @SaldoOrigen = Saldo FROM Saldos WHERE id = @idOrigen;

        IF @SaldoOrigen >= @Cantidad
        BEGIN
            -- Restar la cantidad de la cuenta origen
            UPDATE Saldos SET Saldo = Saldo - @Cantidad WHERE id = @idOrigen;

            -- Sumar la cantidad a la cuenta destino
            UPDATE Saldos SET Saldo = Saldo + @Cantidad WHERE id = @idDestino;
		    INSERT INTO Transacciones VALUES(@idOrigen,@idDestino,@Cantidad)
            COMMIT;
            PRINT 'Transacción completada exitosamente.';

        END
        ELSE
        BEGIN
            ROLLBACK;
            PRINT 'Saldo insuficiente en la cuenta origen.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error en la transacción. Se ha realizado un rollback.';
		THROW 51000,'Error al realizar la transferencia', 1;
    END CATCH;
END;

USE BancoTich
SELECT * FROM Saldos
SELECT * FROM Transacciones

EXEC TransaccionesId @idOrigen=1, @idDestino=2, @Cantidad=300000