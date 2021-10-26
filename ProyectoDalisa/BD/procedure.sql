USE DALISA
GO
CREATE OR ALTER PROCEDURE SP_INGRESAR(@USE VARCHAR(15),@PASS VARCHAR(15))
AS
BEGIN
SELECT * FROM TBLUSUARIO  AS U 
join TBLBANCO AS B ON B.[ID BANCO] = U.[ID BANCO]
WHERE (U.[USE] =@USE AND U.[PASS]=@PASS) AND (U.ELIMINADO=0)
END
GO

SP_INGRESAR 'SAM29','SAM'

CREATE OR ALTER PROCEDURE SP_CONSULTAR_USUARIO_CORREO(@CORREO VARCHAR(40))
AS
BEGIN 
SELECT * FROM TBLUSUARIO  AS u join TBLBANCO AS B ON B.[ID BANCO] = U.[ID BANCO]
WHERE  (U.ELIMINADO=0 and u.[CORREO USE] =@CORREO); 
END
GO

CREATE OR ALTER PROCEDURE SP_UPDATE_PASSOWRD_USUARIO(@PASS VARCHAR(15),@COD VARCHAR(15))
AS
BEGIN 
BEGIN TRY  
  UPDATE TBLUSUARIO
  SET PASS=@PASS
  WHERE ([ID USUARIO]= @COD  AND ELIMINADO=0);
  SELECT 1;
END TRY  
BEGIN  ERROR_STATE()  CATCH  
   SELECT 0;
END CATCH  
END
GO

EXECUTE  SP_INGRESAR 'SAM29','SAM'
EXECUTE  SP_INGRESAR 'JEFRY29','DAVID'
EXECUTE SP_CONSULTAR_USUARIO_CORREO 'i201922732@cibertec.edu.pe'
EXECUTE SP_UPDATE_PASSOWRD_USUARIO 'SANDRA QUECARA OSCCO MANUELA','S0001'
SELECT * FROM TBLUSUARIO

Create or alter Procedure SP_BANCO_LISTAR
as
  begin
  select [ID BANCO],[NOMBRE BNC],[TIPO AHORRO], from Compras.categorias
  end 
  go

  Create or alter Procedure SP_BANCO_LISTAR
as
  begin
  select [ID BANCO],[NOMBRE BNC],[TIPO AHORRO], from Compras.categorias
  end 
  go

  --------------------------------------------------------------------
  CREATE OR alter Proc usp_Usuario_Activo
as
begin
SELECT * FROM TBLUSUARIO  AS U 
join TBLBANCO AS B ON B.[ID BANCO] = U.[ID BANCO] where U.[ELIMINADO] = '0'
  end
  go


  Create proc usp_UsuarioInsetar
  @pais varchar(100),@nombre int , @apellido int,
  @fechanac varchar(50),@estadociv decimal,@stock int
  as
   begin
   insert Compras.productos(NomProducto,IdProveedor,IdCategoria,CantxUnidad,
   PrecioUnidad,UnidadesEnExistencia,UnidadesEnPedido,Activo)
   Values (@nombreproducto,@idproveedor,@idcategoria,@umedida,
   @preciounidad,@stock,0,1)
   end
   go
