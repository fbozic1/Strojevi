PGDMP                          {            Strojevi    15.1    15.1                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16398    Strojevi    DATABASE     ?   CREATE DATABASE "Strojevi" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Croatian_Croatia.1252';
    DROP DATABASE "Strojevi";
                postgres    false            ?            1259    16647    kvarovi    TABLE     o  CREATE TABLE public.kvarovi (
    kvaroviid integer NOT NULL,
    nazivstroja character varying(255),
    nazivkvara character varying(255) NOT NULL,
    prioritet character varying(15) NOT NULL,
    datumpocetka date NOT NULL,
    datumzavrsetka date,
    opiskvara character varying NOT NULL,
    statuskvara character varying(10) NOT NULL,
    CONSTRAINT chk_prioritet CHECK ((((prioritet)::text = 'nizak'::text) OR ((prioritet)::text = 'srednji'::text) OR ((prioritet)::text = 'visok'::text))),
    CONSTRAINT chk_statuskvara CHECK ((((statuskvara)::text = 'otklonjen'::text) OR ((statuskvara)::text = 'ne'::text)))
);
    DROP TABLE public.kvarovi;
       public         heap    postgres    false            ?            1259    16646    kvarovi_kvaroviid_seq    SEQUENCE     ?   CREATE SEQUENCE public.kvarovi_kvaroviid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.kvarovi_kvaroviid_seq;
       public          postgres    false    217            	           0    0    kvarovi_kvaroviid_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.kvarovi_kvaroviid_seq OWNED BY public.kvarovi.kvaroviid;
          public          postgres    false    216            ?            1259    16617    strojevi    TABLE     d   CREATE TABLE public.strojevi (
    strojeviid integer NOT NULL,
    naziv character varying(255)
);
    DROP TABLE public.strojevi;
       public         heap    postgres    false            ?            1259    16616    strojevi_strojeviid_seq    SEQUENCE     ?   CREATE SEQUENCE public.strojevi_strojeviid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.strojevi_strojeviid_seq;
       public          postgres    false    215            
           0    0    strojevi_strojeviid_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.strojevi_strojeviid_seq OWNED BY public.strojevi.strojeviid;
          public          postgres    false    214            k           2604    16650    kvarovi kvaroviid    DEFAULT     v   ALTER TABLE ONLY public.kvarovi ALTER COLUMN kvaroviid SET DEFAULT nextval('public.kvarovi_kvaroviid_seq'::regclass);
 @   ALTER TABLE public.kvarovi ALTER COLUMN kvaroviid DROP DEFAULT;
       public          postgres    false    216    217    217            j           2604    16620    strojevi strojeviid    DEFAULT     z   ALTER TABLE ONLY public.strojevi ALTER COLUMN strojeviid SET DEFAULT nextval('public.strojevi_strojeviid_seq'::regclass);
 B   ALTER TABLE public.strojevi ALTER COLUMN strojeviid DROP DEFAULT;
       public          postgres    false    214    215    215                      0    16647    kvarovi 
   TABLE DATA           ?   COPY public.kvarovi (kvaroviid, nazivstroja, nazivkvara, prioritet, datumpocetka, datumzavrsetka, opiskvara, statuskvara) FROM stdin;
    public          postgres    false    217   ?                  0    16617    strojevi 
   TABLE DATA           5   COPY public.strojevi (strojeviid, naziv) FROM stdin;
    public          postgres    false    215                     0    0    kvarovi_kvaroviid_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.kvarovi_kvaroviid_seq', 15, true);
          public          postgres    false    216                       0    0    strojevi_strojeviid_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.strojevi_strojeviid_seq', 7, true);
          public          postgres    false    214            o           2606    16622    strojevi strojevi_naziv_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.strojevi
    ADD CONSTRAINT strojevi_naziv_key UNIQUE (naziv);
 E   ALTER TABLE ONLY public.strojevi DROP CONSTRAINT strojevi_naziv_key;
       public            postgres    false    215            p           2606    16655     kvarovi kvarovi_nazivstroja_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.kvarovi
    ADD CONSTRAINT kvarovi_nazivstroja_fkey FOREIGN KEY (nazivstroja) REFERENCES public.strojevi(naziv);
 J   ALTER TABLE ONLY public.kvarovi DROP CONSTRAINT kvarovi_nazivstroja_fkey;
       public          postgres    false    215    3183    217                 x?}?AN?0E??S???4Q٢?"Bb??@Fȱ?D?ˢw????ӄ4j;[????????׷?<??:??"/6Y.3Y¾?N,?????ׇ%l?K?^	jFG?J?v?????}?]lK?Y?>h?ۖ?(aW??@??`I??pf??l??!&F??0<?	??:?bHw\???Y???????cw0AaGå?Z?E~9?ܤ|??
??ƶ*%??˲&j?,?TN????k??	???7?qg??M????I?j?0???bo???X?7B??0          V   x?3?.)??R?JT((J=?01/+?ˈ?5'5??(?Ho^?BJfUbNfr"?	BmIfq6X?)?cNbI^?B1H?˜???ʎ???? y? +     