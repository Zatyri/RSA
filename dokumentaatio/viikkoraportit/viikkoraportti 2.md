# Mitä tein viikon aikana
Toteutin viikon alussa naiviin version RSA salausposessista. Tavoitteena oli ymmärtää miten kokonaisuus istuu yhteen. Sain varsin nopeasti tehtyä RSA salauksen ja purkauksen kun viesti oli numeroita. Naivii ohjelma toimi kovakoodatuilla parametreilla (alkuluvut, salattava viesti jne.) ja tulosti viestin konsoliin salaamattomana, salattuna ja purettuna. Viestin vaihtaminen tekstimuotoon aiheutti pientä päänvaivaa mutta sain ASCIIEncoding paketilla homman toimimaan. Tässä vaiheessa tuli esille vistin pituus. Käytin alussa pieniä alkulukuja jotka eivät mahdollistaneet montaa kirjainta viestissä. Viestien pilkkominen osiin on ongelma jonka minun pitää ratkaista ohjelmassa.

Seuraavaksi aloitin alkulukujen luonti algoritmin. Tiestin tarvitsevani isoja numeroita ja tämä aiheutti paljon päänvaivaa C# kielessä. BigInteger luokan käyttäminen sisältää omia haasteita eikä tämä ollut tuttua minulle ennestään. Ymmärrän vihdoin mitä ongelmat isojen lukujen kanssa käytännössä tarkoittaa. Erityisen ongelmalliseksi osottautui isojen satunnaisnumeroiden luonti. 

Miller-Rabin algoritmin toteuttaminen osottautui melko suoraviivaiseksi. Palaan myöhemmässä vaiheessa algoritmiin mahdollisia optimointeja varten.

Mahdollistin koodin testikattavuuden seuraamisen codecov:in kanssa. Testikattavuus on kirjoittaessa vain 64% koska en kirjoita testeja naiviille ohjelmaversiolle. PrimeService luokan testikattavuus on kuitenkin 94%.

Loin myös SandCastle palvelun avulla sivuston jonka avulla voi lukea dokumentaatiota. 

Käytin viikon aikana noin 10 tuntia

# Mitä opin
Optin mitkä ovat käytännön ongelmat kun C# kielessä käytetään isoja lukuja. Kirjoittamalla ohjelmasta naiviin version opin lisää, siitä mitä haasteita ohjelman toteutuksen aikana pitää ratkaista. Esimerkkinä viestien pilkkominen osiin. Codecov:in ja GitHub Actionsien käyttö C# kielen kanssa oli uusi asia jonka opin. SandCastle oli minulle täysin uusi tuttavuus.

# Tämä on epäselvää
Testit alkulukujen generointiin pitää vielä miettiä läpi. Tällä hetkellä ei ole ammattimaista testausta niille. Enkä ole ihan varma mikä olisi tähän paras lähestymistapa.

# Mitä seuraavaksi
Seuraavaksi toteutan "oikean" ohjelman joka luo salaisen ja julkisen avaimen ja tallentavat nämä tiedostoon. Jos aikaa jää aloitan salaus ja purku toiminnallisuuden. Ohjelma ei kuitenkan vielä tule ottamaan syötteitä vastaan.
