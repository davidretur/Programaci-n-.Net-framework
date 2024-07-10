/*1. Hacer una función valuada en tabla que obtenga la tabla de amortización de los 
Reembolsos quincenales que un participante tiene que realizar en 6 meses*/

CREATE OR ALTER FUNCTION Reembolsosquincenales
(
@sueldo int,
@meses int
)
RETURNS @tablaamortizacion TABLE
(
       Quincena SMALLINT,
       [Saldo Anterior] DECIMAL,
       Pago DECIMAL,
	   [Saldo Nuevo] DECIMAL
)
AS
BEGIN
		DECLARE @TotalPagar DECIMAL(10,1)
		DECLARE @SaldoAnterior DECIMAL(10,1)
		DECLARE @Pago DECIMAL(10,1)
		DECLARE @SaldoNuevo DECIMAL(10,1)
        DECLARE @Contador DECIMAL(10,1)
        DECLARE @Periodos DECIMAL(10,1)
		DECLARE @PagoQuincenal DECIMAL(10,1)

		SET @Periodos = @meses * 2
		SET @TotalPagar = @sueldo * 2.5
		SET @PagoQuincenal = @sueldo * 2.5 / @Periodos
		SET @SaldoNuevo = @TotalPagar - @PagoQuincenal
SET @Contador = 1
SET @SaldoAnterior = @TotalPagar
		WHILE @Contador <= @Periodos
BEGIN
	Insert into @tablaamortizacion values
	(@Contador,@TotalPagar,@PagoQuincenal,@SaldoNuevo)
SET @TotalPagar = @TotalPagar - @PagoQuincenal
SET @SaldoNuevo = @SaldoNuevo - @PagoQuincenal
Set @Contador=@Contador+1
END
       RETURN 
END
GO

SELECT * FROM Reembolsosquincenales(22000,6)

/*2. Hacer una función valuada en tabla que obtenga la tabla de amortización
de los préstamos posibles que se le pueden hacer a un instructor.
La función recibirá como parámetro el id del instructor
El importe del préstamo será 200 veces la cuota por hora
El porcentaje de interés será el 24% anual cuando la cuota por hora sea superior a 200
Para el resto será de 18%
El pago mensual será el equivalente a 25 horas*/

use InstitutoTich

CREATE OR ALTER FUNCTION prestamosPosibles
(
@id int
)
RETURNS @tablaamortizacion TABLE
(
       Mes SMALLINT,
       [Saldo Anterior] DECIMAL,
	   Intereses DECIMAL,
       Pago DECIMAL,
	   [Saldo Nuevo] DECIMAL
)
AS
BEGIN
		DECLARE @CuotaHora DECIMAL(10,1)
		DECLARE @Prestamo DECIMAL(10,1)
		DECLARE @TasaMens float
		DECLARE @Tasa float
		DECLARE @Amortizacion float
		DECLARE @UltAmortizado float
		DECLARE @TotAmortizado float
		DECLARE @Cuota float
		DECLARE @Total float
		DECLARE @Interes float
		DECLARE @TasaT1 float
		DECLARE @CuotaC1 float
		DECLARE @Periodos float
        DECLARE @CuotaC1mT1 float
		DECLARE @Contador float
		DECLARE @SaldoAnterior float


	if(@CuotaHora > 200)
		SET @Tasa = 0.24
	ELSE
		SET @Tasa = 0.18
SET @CuotaHora = (select cuotaHora from Instructores where id = @id)
SET @Prestamo = @CuotaHora * 200
Set @Periodos=9
Set @TasaMens=@Tasa/12
Set @TasaT1=@Prestamo*@TasaMens
Set @CuotaC1=@Prestamo*((power(1+@TasaMens,@Periodos)*@TasaMens)/(power(1+@TasaMens,@Periodos)-1))
Set @CuotaC1mT1=@CuotaC1-@TasaT1
SET @SaldoAnterior = @Prestamo
		Set @Amortizacion=@CuotaC1-@TasaT1
		Set @UltAmortizado=@CuotaC1-@TasaT1
		Set @Total=@Prestamo-@Amortizacion
SET @Contador = 1
		WHILE @Contador <= @Periodos
BEGIN
	Set @Interes=(@Prestamo-@CuotaC1mT1*(power(1+@TasaMens,@Contador-1)-1)/@TasaMens)*@TasaMens	
	Set @Cuota=@Prestamo*((power(1+@TasaMens,@Periodos)*@TasaMens)/(power(1+@TasaMens,@Periodos)-1))
	SET @SaldoAnterior = @SaldoAnterior - @Cuota + @Interes
	Set @Amortizacion=@Cuota-@Interes
	Set @TotAmortizado=@Amortizacion+@UltAmortizado


	Insert into @tablaamortizacion values
	(@Contador,@SaldoAnterior,@Interes,@Cuota,@Total)
	
	Set @UltAmortizado=@Amortizacion+@UltAmortizado

	Set @Total=@Total-@Amortizacion

Set @Contador=@Contador+1
END
       RETURN 
END
GO

SELECT * FROM prestamosPosibles(2)