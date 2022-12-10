# Viikkoraportti 6

# Mitä tein viikon aikana
Saadun vertaisplautteen perusteella muokkasin Program-luokan IO kutsut omiin funktioihin joka selkeyttää koodia. Tein myös alkulukujen O-analyysit ja dokumentoin ne. Lisäsin ohjelmaan Sieve of Eratosthenes-algoritmin jolla voi luoda eri kokoisia alkuluku listoja, jolla ohjelma tekee "alkutarkistuksen" ennen Miller-Rabin algoritmia. Aikaisemmin oli vain kovakoodattu 100 ensimmäistä alkulukua lista. Pieniä suorituskyky parannuksia on havaittavissa kun kasvattaa alkuluku listaa. 

Codecov testi-kattavuusraportti jättää nyt huomioimatta Program ja IOService luokat, koska ne sisältävä ainoastaan käyttäjäsyötteitä.

Käytin viikon aikana noin 7 tuntia

# Mitä opin
Opin miten Sieve of Eratosthenes algoritmi toteutetaan. 

# Tämä on epäselvää
Kaikki on tällä erää selvää

# Mitä seuraavaksi
Voisin vielä toteuttaa oman suorituskyky-analyysin joka vertaa ohjelman suorituskykyä suorituskyvyn parannusta kun lisää alkutarkistuksia (kovakoodattu tai Sieve of Eratosthenes) ennen Miller-Rabin testiä. Dokumentteja pitää myös hienosäätää ennen palautusta
