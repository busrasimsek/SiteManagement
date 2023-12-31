# SiteManagement

#Projenin Calıştırılması için gereken ayarlamalar :

    * // Postgresql => SiteManagement.sql backup dosyası
        appsettings.json = >  
            "ConnectionStrings": {
                "EfDbContext": "User ID=postgres;Password={Şifre};Host=localhost;Port={Port};Database=SiteManagement;" } 

    * // Gerekli Smtp ayarlamalarının yapılması.
      // Yöneticinin kullanıcı oluşturması sonucunda random oluşturulan şifrenin kullanıcıya iletilmesi için.

        appsettings.json = > 
            "SmtpConfiguration": { 
                "Host": "-",
                "Port": 587,
                "From": "-",
                "UserName": "-",
                "Password": "-",
                "EnableSSL": true,
                "UseDefaultCredentials": false,
                "IsBodyHtml": true }   

    * // Log için ise Docker da Seq run edilmesi.

    * // Identity/Login Endpoint in den username="busra" password="AaY-e?" yönetici, username="esra" password= "_+@aJ[" user
      // Token oluşturup Autorize dan Bearer + Token şeklinde giriş yapabilirsiniz

    * // Proje dosyasındaki postman.json dosyasını Postman'a import edebilirsiniz.

<b>

1.Adım  : Proje isterlerinin analiz edilerek çıkarılması.

2.Adım  : Veri tabanı tablolarının belirlenip kurgulanması.

3.Adım  : Katmanların oluşturulması. (Core, Data, Business, Api).

4.Adım  : Data katmanında Entity lerin hazırlanması.

5.Adım  : EF core kullanılarak context in oluşturulaması ve database bağlantısı için configuration ların yapılandırılması.

6.Adım  : Code First yaklaşımı uygulamak için gerekli paketlerin(Tool, Design) import edilmesi ve Migration uygulanması.

7.Adım  : Repository lerin oluşturulması ve register edilmesi.

8.Adım  : İşlemlerin toplu halde tek bir kanaldan gerçekleşmesini sağlamak için UnitOfWork Design Pattern inin uygulanmasi.

9.Adım  : Core Katmanında StatusCode lar için baseresponse yapısının kurgulanması ve oluşturulması.

10.Adım : AutoMapper kullanılarak query response ve command requestlerin entity ile birbirleriyle eşleştirilmesi.

11.Adım : Business Katmanında MediatR patterninin uygulanması. Command ve Query(CQRS pattern) lerin oluşturulmasi. 

12.Adım : FluentValidation kullanarak Model lere gerekli validationların eklenmesi. 

13.Adım : AutoMapper, FluentValidation, MediatR register edilmesi.

14.Adım : Core Katmanında mail service nin oluşturulmasi.

15.Adım : Password hash ve salt için helper oluşturulmasi.

16.Adım : Authentication için token servisinin oluşturulması. Program.cs içerisinde gerekli configurationların yapılması.

17.Adım : Autorize için Swagger cofigurationların yapılmsı.

18.Adım : Controllerda gerekli endpointlerin yazılması. Gerekli yetkilendirmeler için entpointlere Autorize attributunun role uygun olarak eklenmesi.

</b>

<img src="img/SiteManagementPostman.png">
<img src="img/SiteManagementSwagger.png">