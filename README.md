# Proyecto Web Completo

Este repositorio contiene el código fuente del proyecto web completo desarrollado por Guillermo Álvarez. El proyecto incluye la administración de usuarios, gestión de amputaciones, y varios componentes de un sistema web.

## Descripción

Se propone implementar un servicio de venta hacia el público con alguna discapacidad que tenga una amputación, con el objetivo de proporcionar una compra de una manera rápida, fácil y de la manera más comprensiva posible, ayudándolo a elegir la mejor opción protésica para el cliente.

## Explicación del Core

El core del sistema está centrado en la evaluación de la efectividad de los componentes utilizados en la creación de prótesis, lo cual proporciona a los administradores y personal protesista una visión clara del rendimiento de estos elementos basada en la durabilidad y el desempeño en diversas actividades y estilos de vida de los usuarios de prótesis.

Para lograr esto, el seguimiento de los componentes de las prótesis requiere un registro detallado de su uso por parte de los pacientes, incluyendo información sobre el estilo de vida de cada usuario, los componentes utilizados, la duración de los componentes y cualquier incidente que pueda afectar su funcionalidad. Este registro actuará como un respaldo para los especialistas y al sistema de prótesis al recomendar componentes específicos para cada cliente, así como para determinar la durabilidad y el rendimiento de los componentes en situaciones reales.

Los administradores y supervisores tendrán acceso a una interfaz que les permitirá visualizar el desempeño de los componentes de las prótesis y las recomendaciones generadas para cada usuario. Esta información les ayudará a tomar decisiones informadas sobre la selección de componentes y a realizar ajustes en las recomendaciones según sea necesario para mejorar la calidad de las prótesis ofrecidas.

### Evaluación de la Efectividad de los Componentes

Para la evaluación de la efectividad de los componentes utilizados en la creación de prótesis y la recomendación personalizada para cada cliente, se propone implementar el siguiente esquema de valoración:

1. **Recopilación de Datos**:
    - Obtener información detallada sobre los pacientes y su estilo de vida.
    - Registrar la duración de los componentes.

2. **Análisis de Datos**:
    - Filtrar y agrupar los datos de los pacientes por características similares de estilo de vida y actividades.
    - Calcular el tiempo total de uso de cada componente y su efectividad en el contexto del estilo de vida del paciente.

3. **Generación de Recomendaciones**:
    - Utilizar algoritmos de análisis para identificar patrones y tendencias en los datos recopilados.
    - Recomendar componentes de prótesis específicos para cada cliente basándose en su estilo de vida y las características de los componentes disponibles en el mercado.

4. **Evaluación de la Efectividad**:
    - Calcular el puntaje total y el puntaje promedio de los componentes de la prótesis utilizados por cada paciente.
    - Evaluar la efectividad de las recomendaciones realizadas en función de la durabilidad.

### Alcance del Core

El proyecto se centrará en desarrollar funcionalidades para los administradores, técnicos protesista y usuarios. Para lograr esto, el sistema requerirá un proceso de inicio de sesión previo para autorizar el acceso de cada usuario a las funciones correspondientes según su rol asignado. A continuación, se detallan las funcionalidades para cada tipo de usuario:

1. **Gestión de Usuarios**:
    - Los administradores tendrán la capacidad de crear, modificar, eliminar y consultar información sobre los usuarios del sistema, incluyendo detalles como nombre e información de contacto.
    - Podrán asignar roles específicos a cada usuario, como administrador, técnico o usuario en caso de ser necesario.

2. **Gestión de Componentes Protésicos**:
    - Los administradores y técnicos protesista podrán gestionar la base de datos de componentes protésicos, incluyendo su nombre, descripción, durabilidad estimada y características técnicas.
    - Podrán crear, modificar, eliminar y consultar los componentes disponibles en el sistema.

3. **Asignación de Componentes a Usuarios**:
    - Los técnicos podrán asignar componentes específicos a cada usuario de prótesis, basándose en las recomendaciones generadas por el sistema. En caso de que surja una novedad con alguna de las piezas, el técnico podrá añadirlo como incidencia.
    - Podrán registrar los componentes asignados a cada usuario.

4. **Consulta de Estadísticas de Componentes**:
    - Se mostrarán gráficos y tablas que presenten información sobre la vida útil promedio de los componentes.

Gracias a todas estas funcionalidades, el sistema proporcionará una plataforma completa para la gestión integral de componentes protésicos, desde su selección y asignación hasta el seguimiento del desempeño y la generación de informes de productividad. Esto garantizará una mejor experiencia para los usuarios de prótesis y una mayor eficiencia en la gestión de recursos por parte de los administradores y supervisores.

## Enlaces Importantes

- **Repositorio en GitHub**: [Proyecto Web Completo](https://github.com/Guiller438/ProyectoWebCompleto)
- **Despliegue en Producción**: [Proyecto Desplegado](http://guiller269-001-site1.gtempurl.com/Users/Login)
- **Jira**: [Link de Jira](https://udlaec.sharepoint.com/:v:/s/Section_1151287205/Ebzeooe0A65Eg9uZAGrtBE0BHXBwcbu3rHVAZcNqnKzsQQ?e=V2QQ6O&nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJTdHJlYW1XZWJBcHAiLCJyZWZlcnJhbFZpYWxMaW5rIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXcifX0%3D)
- **Defensa (Reto)**: [Link de Defensa (Reto)](https://udlaec.sharepoint.com/:v:/s/Section_1151287205/EWxtRWePY3VMqXfigIH0U_0BulT6sq85LGGhaDL1aJNPJg?e=kkKvPP&nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJTdHJlYW1XZWJBcHAiLCJyZWZlcnJhbFZpYWxMaW5rIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXcifX0%3D)
- **Defensa (Core)**: [Link de Defensa (Core)](https://udlaec.sharepoint.com/:v:/s/Section_1151287205/ETLkeedwdPVBpeGWa9foO2wB05TNVho9a2h3NO4_clN_JA?e=QOTwA0&nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJTdHJlYW1XZWJBcHAiLCJyZWZlcnJhbFZpYWxMaW5rIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXcifX0%3D)

## Credenciales de Acceso

Para acceder a la aplicación desplegada, puedes utilizar las siguientes credenciales:

- **Usuario**: `11181871`
- **Contraseña**: `60-dayfreetrial`

Acceso para el programa
- **Usuario** : 1723001572
- **Contraseña** : ProyectoWebSoftware7@
  
## Configuración

Para configurar el proyecto localmente, sigue estos pasos:

1. Clona el repositorio:
   ```bash
   git clone https://github.com/Guiller438/ProyectoWebCompleto.git
