select * from kvarovi

select * from strojevi

CREATE TABLE Kvarovi(
   KvaroviID SERIAL NOT NULL,
   NazivStroja VARCHAR(255) REFERENCES Strojevi(Naziv) ,
   NazivKvara VARCHAR(255) NOT NULL,
   Prioritet VARCHAR(15) NOT NULL,
   DatumPocetka date NOT NULL,
   DatumZavrsetka date NULL,
	OpisKvara VARCHAR NOT NULL,
	StatusKvara varchar(10) NOT NULL,
	CONSTRAINT CHK_Prioritet CHECK (Prioritet = 'nizak' OR Prioritet = 'srednji' OR Prioritet = 'visok'),
	CONSTRAINT CHK_StatusKvara CHECK (StatusKvara = 'otklonjen' OR StatusKvara = 'ne')
);


CREATE TABLE Strojevi(
   StrojeviID SERIAL NOT NULL,
   Naziv VARCHAR(255) UNIQUE
);


delete from

 SELECT kvarovi.nazivkvara,kvarovi.prioritet,kvarovi.opiskvara,kvarovi.statuskvara,AVG(DATE_PART('day', datumzavrsetka::timestamp - datumpocetka::timestamp)) as ProsjecnoTrajanjeKvarova from kvarovi LEFT join strojevi on strojevi.naziv=kvarovi.imestroja
GROUP BY kvarovi.nazivkvara,kvarovi.prioritet,kvarovi.opiskvara,kvarovi.statuskvara,kvarovi.datumpocetka order by prioritet asc, datumpocetka desc offset 3 rows fetch next 3 rows only

SELECT COUNT(*) FROM Kvarovi WHERE imestroja = 'Stroj za prešu' and statuskvara = 'ne'
select * from kvarovi order by prioritet asc,datumpocetka desc

UPDATE kvarovi set nazivkvara='testiranje',prioritet = 'visok' where kvaroviid=1


SELECT 
                        strojevi.strojeviid,
                        strojevi.naziv, 
                        kvarovi.kvaroviid,
                        kvarovi.nazivkvara, 
                        kvarovi.prioritet, 
                        kvarovi.opiskvara, 
                        kvarovi.statuskvara, 
                        AVG(DATE_PART('day', kvarovi.datumzavrsetka::timestamp - kvarovi.datumpocetka::timestamp)) as ProsjecnoTrajanjeKvarova 
                      FROM kvarovi 
                      INNER JOIN strojevi 
                      ON strojevi.naziv = kvarovi.nazivstroja 
                      GROUP BY 
                        strojevi.strojeviid,
                        strojevi.naziv, 
                        kvarovi.kvaroviid,
                        kvarovi.nazivkvara, 
                        kvarovi.prioritet, 
                        kvarovi.opiskvara, 
                        kvarovi.statuskvara, 
                        kvarovi.datumpocetka


select * from kvarovi

select strojevi.naziv,kvarovi.nazivkvara,kvarovi.prioritet,kvarovi.opiskvara,kvarovi.statuskvara,AVG(DATE_PART('day', datumzavrsetka::timestamp - datumpocetka::timestamp)) as ProsjecnoTrajanjeKvarova from kvarovi 
inner join strojevi on strojevi.naziv=kvarovi.nazivstroja
WHERE strojeviid = 1
GROUP BY strojevi.naziv,kvarovi.nazivkvara,kvarovi.prioritet,kvarovi.opiskvara,kvarovi.statuskvara,kvarovi.datumpocetka 
order by prioritet asc, datumpocetka desc 
offset 2 rows fetch next 3 rows only

select * from kvarovi
INSERT INTO Kvarovi(imestroja,nazivkvara,prioritet,datumpocetka,datumzavrsetka,opiskvara,statuskvara) VALUES ('Mlazna perilica','test','visok','2023-01-02','2023-01-14','test','ne') 