--1. REPASAR CONCEPTOS DE BASES DE DATOS

use EjerciciosTich

--3. PLANTEAMIENTO DEL PROBLEMA BASADO EN EXPERIENCIA PERSONAL
--Realizar el planteamiento de un problema para el desarrollo de una aplicaci�n que haya utilizado 
--en su experiencia laboral, o en su caso una hipot�tica de un �mbito de su inter�s. Tal como, 
--el desarrollo de una aplicaci�n para el control de Ventas en una tienda.

-- Escenario: 
CREATE TABLE Pedido (
    PedidoID int,
    FechaPedido date,
    ClienteID int,
    NombreCliente varchar(255),
    Direcci�n varchar(255),
    ProductoID int,
    NombreProducto varchar(255),
    Precio decimal
);

INSERT INTO Pedidos (PedidoID, FechaPedido, ClienteID, NombreCliente, Direcci�n, ProductoID, NombreProducto, Precio)
VALUES (1, '2024-01-23', 123, 'Juan P�rez', 'Calle Falsa 123', 456, 'Producto X', 19.99);

---SQL para Normalizaci�n

-- Crear tabla Clientes
CREATE TABLE Clientes (
    ClienteID int PRIMARY KEY,
    NombreCliente varchar(255),
    Direcci�n varchar(255)
);

-- Crear tabla Productos
CREATE TABLE Productos (
    ProductoID int PRIMARY KEY,
    NombreProducto varchar(255),
    Precio decimal
);

-- Crear tabla Pedidos
CREATE TABLE Pedidos (
    PedidoID int PRIMARY KEY,
    FechaPedido date,
    ClienteID int,
    ProductoID int,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);