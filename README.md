# Prim_Kruskal

Sistema computacional que genera un grafo a partir de la imagen analizada, cada círculo de la imagen representa a un vértice y cada vértice contiene
adyacencias (aristas) que lo conecta con todos los demás siempre y cuando se pueda trazar una línea recta desde un vértice (origen) a otro (destino). 
Cualquier figura en la imagen puede obstruir la conexión de un vértice a otro, incluso los mismos vértices.
Muestra un árbol de recubrimiento mínimo (ARM) del grafo. Si el grafo no es conexo, debe mostrar el conjunto de ARMs para cada subgrafo conexo, además, 
debe identificar el número de subgrafos que contiene.

El sistema tendrá la posibilidad de analizar un ARM para lograr un conjunto de recorridos, en los que a partir de un vértice seleccionado, se
desplacen k1 partículas (una a cada arista), cada partícula recorrerá una rama del árbol, en caso de que exista un vértice en el camino, que crea k2 ramas,
la partícula debe dividirse en esa cantidad para recorrerlas todas al mismo tiempo. La división de la partícula exige un cambio morfológico, su tamaño disminuye 
dependiendo de las divisiones que realizó en una relación 1:1.

Los recorridos podrán verse de forma animada, la(s) partículas se desplazan desde un vértice a otro a través de sus aristas. El desplazamiento es visualmente
progresivo (se desplaza sobre la arista). El usuario puede elegir la posición inicial de la animación que recorrerá al árbol de expansión mínima, y la densidad 
(diámetro) inicial de la partícula que se utilizará para los recorridos. Las partículas tienen un límite inferior de diámetro, si una partícula se vuelve más
pequeña que ese límite, la partícula desaparece.

## Objetivo
Crear un programa con interfaz gráfica que permita analizar imágenes e identificar su grafo
mediante el análisis de los círculos y su trayectoria con otros, y a partir de ello crear un
analisis para identificar un circuito de Prim y otro de Kruskal, además de crear una
animación que permita mostrar dicho circuito.

## Diagrama de clases UML
![imagen](https://github.com/JE-SH/Prim_Kruskal/assets/73598536/7994a3d5-ba2c-4f26-ac44-e065eda39bf2)

## Desarrollo
Find center es un método en el que a partir de un pixel diferente de blanco y de un color específico de azul,
verifica si es un circulo mediante operaciones que implican el radio de lo que puede ser el circulo, si lo es,
lo pinta de un color azul para no analizarla de nuevo, ocurriendo en un bitmap secundario. Cuando termina de 
analizar toda la imagen en busca de círculos el programa, la imagen que se muestra será la original sin pintar 
para darle una mejor apariencia, después, se manda llamar a la clase Graph el cual se le mandará el bitmap 
principal, la lista generada de los círculos en la imagen y el picture box de la imagen principal. Ahí mismo 
se crean los vértices a partir de la lista de círculos. Luego se manda llamar al método de findConection donde 
habrá dos vértices y un flotante que servirán para saber cuales son los dos puntos más cercanos o closest pair 
points. Se crean dos arreglos para hacer las conexiones entre dos vértices, uno de origen y otro de destino.

inGraphConection es un método que recibe dos círculos. Primero se saca la pendiente de la linea entre los dos 
círculos a comparar junto con la variable lineal, todo esto nos permite encontrar los pixeles que recorreremos
en los pixeles de un eje cada pixel en el segundo eje, por ejemplo podrían ser tres pixeles en x cada pixel en
y. Dependiendo de el tipo de pendiente se verifica si es horizontal o vertical para realizar los cálculos 
correctos, de ser así, cuando se localiza el tipo de pendiente y se crea un arreglo desde el punto inicial hasta 
el punto final y va iterando pixel a pixel junto con la pendiente para verificar que no haya ninguna obstrucción 
que sería algún pixel con un color que no se haya previsto, ya sea diferente de un pixel del mismo circulo de 
origen, de destino o del mismo color del que se hace la linea. Posteriormente se saca la distancia entre los dos 
puntos independientemente si tiene obstáculos o no para determinar cuales son los dos puntos más cercanos. 
Terminando esto se imprimen las conexiones entre cada vértice. Dependiendo si encuentra o no una obstrucción se
retorna la distancia entre los dos puntos y se dibuja una linea entre ambos en caso de ser posuble.

Cuando se terminan estas acciones, se llama a findKruskal en el que recibe una lista de
vértices y la lista de las aristas bidireccionales que se creo en la clase grafo. Creamos una
lista de aristas prometedoras, que guardan las aristas que son favorables para la solución del
algoritmo, una arista que será llamada mej, un contador, un total de tipo flotante y una lista
de padre, que guardará el vértice padre del cual se puede derivar un vértice. Mientras la
lista de prometedor sea diferente del total de vértices -1, verifica cual es la arista de menor
valor gracias a un arreglo. Ya que se verificó cual es la arista de menor peso, se agrega la
conexión de los vértices en el textbox, se le asigna un vértice padre a los vértices actuales,
que son los dos vértices que están en la arista siempre y cuando el vértice padre sea
diferente en ambos, se agrega la arista a prometedor y la misma arista se elimina de la lista
de aristas existentes en el grafo. Todo esto se repite hasta la condición de salida o hasta que
alguno de los vértices se quede en nulo, ya que esto significa que hay subgrafos no conexos
y no se puede cumplir la condición. Al final se retorna la lista de aristas prometedoras.
Ya que se haya realizado el análisis de la imagen, se da clic a cualquier vértice de la
imagen, se calcula la relación del zoom respecto con la imagen real para que el clic que se
haya dado sea dentro del vértice, si es así se manda llamar a findPrim, puesto que es
dependiente del vértice inicial.

Para poder realizar la animación de la partícula se ha creado una clase Particle, que se
encarga de guardar una lista de puntos, que gracias a la ayuda de makeLine, nos permite
tener un historial de por qué puntos dentro de la imagen va a aparecer la partícula, como si
fuera un stop motion. Esta clase cuenta como atributos un indice actual, un diámetro de la
partícula actual y la arista en la que se desplaza la partícula.
Cuando el programa se ejecuta, el recuadro de números que se encuentra, permite a la
partícula modificar su diámetro y al mismo tiempo aparecer con los nuevos cambios en
pantalla, y dependiendo si se escogió una imagen para la partícula o no, es como aparecerá.

Cuando se le da clic a un vértice primero se verifica si es de un vértice la ubicación o si es
fuera de este. Cuando se verifica que sea de un vértice se manda llamar al método de Prim,
ya que este depende del vértice que se escoja. El método recibe el vértice inicial, la lista de
vértices y la lista de los pares de aristas de la clase grafo. Aquí se crean dos listas de aristas,
una llamada prometedor y otra se llama candidatos, una lista de vértices llamada padre, una
arista llamada act y un vértice actual. Mientras que los elementos del prometedor sea
diferente de de la cantidad de vértices -1, hará lo siguiente: con un arreglo verifica en la
lista de aristas cuales son las aristas que tienen el vértice actual, y los añade en candidatos,
después con otro arreglo se verifica cual de los candidatos es el menos costoso, a partir de
ahí se verifica si de los dos vértices de la arista tienen el mismo vértice padre, si no es así la
arista actual se convierte en la seleccionada al igual que el vértice, se guarda el número del
indice en el contador, se agrega a un textbox las conexiones, se igualan los vértices padres
de estas, se agrega a prometedor la arista y se elimina de los candidatos. Al final se retorna
la lista de aristas y cuando lo hace se señala el camino en la misma imagen.


