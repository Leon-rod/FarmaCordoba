go

CREATE VIEW V_TOTALES_FACTURADOS_VENDEDORES
AS	
	
	SELECT YEAR(F.FECHA) 'A�O', 
		   MONTH(F.FECHA) 'MES',
		   F.ID_PERSONAL_CARGOS_ESTABLECIMIENTOS 'ID_PERSONAL',
		   P.APELLIDO + ', ' + P.NOMBRE 'PERSONAL',
		   SUM(D.CANTIDAD * D.PRECIO_UNITARIO) 'TOTAL_FACTURADO',
		   MAX(D.CANTIDAD*D.PRECIO_UNITARIO) 'VENTA_MAS_CARA'
	FROM FACTURAS F
		JOIN PERSONAL_CARGOS_ESTABLECIMIENTOS PCE ON PCE.ID_PERSONAL_CARGOS_ESTABLECIMIENTOS =  F.ID_PERSONAL_CARGOS_ESTABLECIMIENTOS
		JOIN DISPENSACIONES D ON D.ID_FACTURA = F.ID_FACTURA
		JOIN PERSONAL P ON P.ID_PERSONAL = PCE.ID_PERSONAL
	GROUP BY YEAR(F.FECHA), MONTH(F.FECHA), P.APELLIDO + ', ' + P.NOMBRE, F.ID_PERSONAL_CARGOS_ESTABLECIMIENTOS
	HAVING SUM(D.CANTIDAD * D.PRECIO_UNITARIO) > (SELECT SBC.PROMEDIO
														FROM (SELECT F1.ID_PERSONAL_CARGOS_ESTABLECIMIENTOS 'ID_PERSONAL_1', AVG(D1.CANTIDAD*(D1.PRECIO_UNITARIO-(D1.DESCUENTO*D1.PRECIO_UNITARIO))) 'PROMEDIO'
															  FROM FACTURAS F1
															  JOIN DISPENSACIONES D1 ON D1.ID_FACTURA = F1.ID_FACTURA
															  WHERE YEAR(F1.FECHA) = YEAR(GETDATE())
															  GROUP BY F1.ID_PERSONAL_CARGOS_ESTABLECIMIENTOS
															  ) AS SBC
														WHERE SBC.ID_PERSONAL_1 = F.ID_PERSONAL_CARGOS_ESTABLECIMIENTOS)


go---------------------------------------------------------------------------------------------------------------------------


---------------------------------------------------------------------------------------------------------------------------	
go

CREATE VIEW V_REPORTE_MENSUAL_OBRA_SOCIAL
AS
Select OS.NOMBRE 'Obra_Social',
	SUM(CASE
			WHEN D.ID_COBERTURA IS NOT NULL THEN (d.CANTIDAD * d.PRECIO_UNITARIO * d.DESCUENTO)
			ELSE 0
			END) 'Importe_a_reintegrar',
	MONTH(f.FECHA) 'Mes',
	YEAR(f.fecha) 'A�o'
FROM DISPENSACIONES D
JOIN TIPOS_COBERTURAS TC ON D.ID_COBERTURA = TC.ID_TIPO_COBERTURA
JOIN OBRA_SOCIAL OS ON TC.ID_OBRA_SOCIAL = OS.ID_OBRA_SOCIAL
JOIN Facturas f ON d.ID_FACTURA = f.ID_FACTURA

GROUP BY OS.NOMBRE, YEAR(f.fecha) ,MONTH(f.FECHA)


GO