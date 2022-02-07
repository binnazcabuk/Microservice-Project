# CoursesMicroserviceProject
Microservis mimarisi kullanılarak oluşturulan çeşitli kategorilerde kurslar satın alabileceğiniz bir web uygulamasıdır.


<hr><b>Catalog Microservice:</b>Kurs ile ilgili bilgilerin tutulmasından ve sunulmasından sorumlu olan mikroservis
<ul>
<li>MongoDB (Veritabanı)</li>
<li>One-To-Many/One-To-One ilişki</li>
</ul>

<hr><b>Basket Microservice:</b>Sepet işlemlerinden sorumlu olan mikroservis
<ul>
<li>Redis(Veritabanı)</li>
</ul>

<hr><b>Discount Microservice:</b>Kullanıcıya tanımlanacak indirim kuponlarından sorumlu olan mikroservis.
<ul>
<li>PostgreSQL(Veritabanı)</li>
</ul>

<hr><b>Order Microservice:</b>Sipariş işlemlerinden sorumlu olan mikroservis
<ul>
<li>Domain Driven Design</li>
<li>Sql Server(Veritabanı)
<li>CQRS (MediatR Libarary)</li>
</ul>

<hr><b>FakePayment Microservice:</b>Ödeme işlemlerinden sorumlu olan mikroservis.

<hr><b>IdentityServer Microservice:</b>Kullanıcı datalarının tutulmasından,token ve refreshtoken üretilmesinden sorumlu olan microservis.
<ul>
<li>Sql Server(Veritabanı)</li>
<li>Token/RefreshToken üretmek</li>
<li>OAuth 2.0</li>
</ul>
<hr><b>PhotoStock Microservice:</b>Kurs fotograflarının tutulmasından ve sunulmasından sorumlu olan mikroservis.

<hr><b>Message Broker:</b>
<ul>
<li>MassTransit Library</li>
<li>RabbitMQ </li>
</ul>

