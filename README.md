# SiteManagement

Projenin Calıştırılması için gereken ayarlamalar : 
    * //Postgresql
    appsettings.json = >  
        "ConnectionStrings": {
            "EfDbContext": "User ID=postgres;Password={Şifre};Host=localhost;Port={Port};Database=SiteManagement;" } 

    * // Gerekli Smtp ayarlamalarının yapılması. Yöenticinin kullanıcı oluşturması sonucunda random oluşturulan şifrenin kullanıcıya iletilmesi için.
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
    * // Log için ise Docker da Seq run edilmesi

1.Adım  : Proje isterlerinin analiz edilerek çıkarılması.
2.Adım  : Tablo yapısının kurgulanması.
3.Adım  : Katmanların oluşturulması.(Core, Data, Business, Api).
4.Adım  : Data katmanında Entity lerin hazırlanması.
5.Adım  : EF core kullanılarak context in oluşturulaması ve database bağlantısı için configuration ların yapılandırılması.
6.Adım  : Code First yaklaşımı uygulamak için gerekli paketlerin(Tool, Design) import edilmesi ve Migration uygulanması.
7.Adım  : Repository lerin oluşturulması ve register edilmesi
8.Adım  : İşlemlerin toplu halde tek bir kanaldan gerçekleşmesini sağlamak için UnitOfWork Design Pattern inin uygulanmasi.
9.Adım  : Core Katmanında StatusCode lar için baseresponse yapısının kurgulanması ve oluşturulması.
10.Adım : AutoMapper kullanılarak query response ve command requestlerin entity ile birbirleriyle eşleştirilmesi.
11.Adım : Business Katmanında MediarR patterninin uygulanması.Command ve Query lerin oluşturulmasi. 
12.Adım : FluentValidation kullanarak Model lere gerekli validationların eklenmesi. 
13.Adım : AutoMapper, FluentValidation, MediatR register edilmesi.
14.Adım : Core Katmanında mail service nin oluşturulmasi
