# Viikkoraportti 1

### Mitä tein viikon aikana
Aloitin kurssin käymällä aloitusluennolla. Kiinnostava aihe löytyi melko nopeasti kryptologian kohdalta, ja valitsin aiheeksi RSA algoritmiin.

Olen viikon aikana ehtinyt tutustua pintapuolisesti RSA salaukseen. Yksi RSA:n keskeimmistä asioista on löytää tarpeeksi suuria alkulukuja, ja niissä piilee algoritmin suurimmat haasteet. Käytin eniten aikaa selvittääkseni miten suuria alkulukuja löytyy, ja huomasin nopeasti, että suosituin tapa on Miller-Rabin testin avulla. Ideana ei siis ole laskea alkuluku vaan arvata se ja testata onko se alkuluku. Ei myöskään ole tehokasta arvata se uudelleen vaan kasvattaa arvattu numero kunnes löydetään alkuluku testin avulla.

Löysin myös viitteitä siihen että ennen "raskasta" Miller-Rabin testiä voisi suorittaa pienillä alkuluvuilla "kevyet" testit arvatulle numerolle. Pieniä alkulukuja ajattelin löytää Sieve of Eratosthenes algoritmilla. Ajattelin myös testata miten suuri vaikutus tällä kevyellä testillä on.

### Mitä opin
Opin tällä viikolla että isojen alkulukujen löytäminen ei ole triviaali asia. Opin myös että on algoritmeja joiden lopputulos on "riittävän" oikein kuten esimerkiksi Miller-Rabin algoritmi, joka ei ole 100% varma, että testattu luku on alkuluku. Algoritmi antaa kuitenkin 100% varmuuden jos testattava luku ei ole alkuluku.
Vaikka RSA on korkealta tasolta tuttu, opin miten julkista ja salaista avainta luodaan.

### Tämä on epäselvää
Epäselväksi jäi vielä julkisen avaimen "co-prime" tai "e" ja myös sen laskeminen. Tämä luku ei ilmeisesti tarvitse olla niin iso. Jossain materiaalissa sanottiin että siihen käytetään yleisesti vakiota 65537.

### Mitä seuraavaksi
Seuraavaksi ajattelin toteuttaa yksinkertaisen ohjelman joka luo vaikona annettujen alkulukujen avulla julkisen ja salaisen avaimen. Salaa viestin ja purkaa sen. Ohjelmalle ei tule sen kummempaa käyttöliittymää, vaan ajetaan debuggerilla IDE:ssa.
