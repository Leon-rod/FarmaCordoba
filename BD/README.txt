1)Para registrar los stocks (cantidad de PRODUCTOS y MEDICAMENTOS_LOTES)
disponibles usamos la tabla STOCK, la cual cada cierto periodo de tiempo se irá
actualizando manualmente luego de un conteo de stock presencial.
Asimismo para cada dispensación, pérdida por robo, mal estado, entre otros, se llevará el
registro a través de una tabla INVENTARIOS con el justificativo correspondiente. Logrando
obtener un stock ‘teórico’ a través de la lógica de programación, sumando los inventarios y
restándole al stock.
------------------------------------------------------------------------------

2)Las cotizaciones se cargan en la página del proveedor y una vez aprobada, el personal
responsable carga el pedido a través de las tablas PEDIDOS y DETALLES_PEDIDOS.
------------------------------------------------------------------------------
3)Como se mencionó anteriormente, las obras sociales envían información mensualmente
sobre los descuentos aplicables a cada medicamento. De manera tal que se irá
actualizando en la tabla TIPOS_COBERTURAS, dejando un registro histórico del descuento
aplicado en cada dispensación, en caso de ser aplicable.
Por lo que para obtener el total con el descuento aplicado se deberá hacer de la siguiente
manera:
cantidad * (precio_unitario - (descuento * precio_unitario))
De esta manera cuando no haya descuento, el campo descuento será 0 y la resta será
precio_unitario - 0.

------------------------------------------------------------------------------
4) Basándonos en la simulación de un caso real donde el registro de las dispensaciones se
llevaban en un archivo de Excel y soporte papel, hemos decidido crear nuestra base de
datos para implementar un registro de los datos más ordenado y eficaz. Para ello, hemos
realizado una migración parcial de los registros existentes entre todos los establecimientos
asociados. Con el fin de tener referencias históricas al procesar datos, se han incluido a su
vez registros de facturas anteriores a la fecha. Asimismo los registros de stock e inventario
fue imposible reconstruirlos, debido a que la mayoría se encontraba en soporte papel.

------------------------------------------------------------------------------
5) Cada medicamento tiene una presentacion, la cual es propia del medicamento y
laboratorio que lo fabrica. Cada medicamento puede haber sido fabricado en diferentes
lotes los cuales tienen números de identificación diferentes en la tabla
MEDICAMENTOS_LOTES.
------------------------------------------------------------------------------
6) La tabla FACTURAS_TIPOS_PAGOS se usa como tabla intermedia entre FACTURAS y
TIPOS_PAGOS a fin de poder llevar registro del tipo de pago y el porcentaje que se
abonará de la factura. En la tabla TIPOS_PAGOS se ha añadido un campo descuento, que
se sumará al campo descuento de la tabla DISPENSACIONES (mencionada en el punto 3).
Entendemos en nuestra experiencia que el único tipo de pago que podría tener un
descuento es en efectivo ya que cuando se trata de entidades bancarias, el reintegro corre
por cuenta de la entidad y no del establecimiento.

------------------------------------------------------------------------------
7) La tabla INVENTARIOS posee las columnas FECHA y CANTIDAD y son NULL. Estas son usadas para casos donde el tipo de movimiento sea por ejemplo ROBO. En estos casos, no se posee una DISPENSACION o DETALLE donde se vea una CANTIDAD o FECHA. Cuando sean movimientos de ventas, compras, etc estos campos irán NULL.
------------------------------------------------------------------------------
