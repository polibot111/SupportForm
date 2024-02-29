Proje Notları

- Proje başlangıcında 3 tane kullanıcı, 2 role, 4 form status, 30 tane de supportform otomatik olarak eklenir.

- Başlangıçta rollerin herhangi bir yetkisi bulunmamaktadır.

- Kullanıclar =

username = "superadmin" password = "123456"
username = "admin" password = "123456"
username = "member" password = "123456"

- superadmin kullanıcısı role bazlı yetkilendirmeden muaftır ve bütün uçları tüketebilir.

- Role bazlı yetkilendirmenin geçerli olduğu uçları "/api/ApplicationServices" ucuna istek atarak görebilirsiniz.

- Rollere yetkileri "/api/AuthorizationEndpoints" ucundan atayabilirsiniz. 
* endpointCodes propertysine hangi değerlerin geleceğini "/api/ApplicationServices" ucundaki Code propertysinden görebilirsiniz. Vermek istediğiniz ucun code unu yazabilirsiniz.

- Rollerin yetkili olduğu uçları "/api/AuthorizationEndpoints/:id" servisinden görebilirsiniz.


