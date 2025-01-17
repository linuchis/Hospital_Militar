PGDMP  )    "            	    |            dbpoxter    16.4    16.4     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16398    dbpoxter    DATABASE     ~   CREATE DATABASE dbpoxter WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Colombia.1252';
    DROP DATABASE dbpoxter;
                postgres    false            �            1259    16482    patients_poxter    TABLE       CREATE TABLE public.patients_poxter (
    id_p bigint NOT NULL,
    name_p character varying(100) NOT NULL,
    lastname_p character varying(100) NOT NULL,
    height_p bigint NOT NULL,
    weight_p bigint NOT NULL,
    gender_p character varying(100) NOT NULL
);
 #   DROP TABLE public.patients_poxter;
       public         heap    postgres    false            �            1259    16459    surveys_patients    TABLE     �  CREATE TABLE public.surveys_patients (
    id_survey "char" NOT NULL,
    hour_survey date NOT NULL,
    "1_survey" character varying(255),
    "2_survey" character varying(255),
    "3_survey" character varying(255),
    "4_survey" character varying(255),
    "5_survey" character varying(255),
    "6_survey" character varying(255),
    "7_survey" character varying(255),
    "8_survey" character varying(255),
    "9_survey" character varying(255),
    "10_survey" character varying(255)
);
 $   DROP TABLE public.surveys_patients;
       public         heap    postgres    false            �            1259    16475    users_poxter    TABLE     �  CREATE TABLE public.users_poxter (
    id_u bigint NOT NULL,
    name_u character varying(100) NOT NULL,
    lastname_u character varying(100) NOT NULL,
    email_u character varying(100) NOT NULL,
    area_u character varying(100) NOT NULL,
    password_u character varying(100) NOT NULL,
    username_u character varying(255) NOT NULL,
    telephone_u character varying(255) NOT NULL
);
     DROP TABLE public.users_poxter;
       public         heap    postgres    false            �          0    16482    patients_poxter 
   TABLE DATA           a   COPY public.patients_poxter (id_p, name_p, lastname_p, height_p, weight_p, gender_p) FROM stdin;
    public          postgres    false    217          �          0    16459    surveys_patients 
   TABLE DATA           �   COPY public.surveys_patients (id_survey, hour_survey, "1_survey", "2_survey", "3_survey", "4_survey", "5_survey", "6_survey", "7_survey", "8_survey", "9_survey", "10_survey") FROM stdin;
    public          postgres    false    215          �          0    16475    users_poxter 
   TABLE DATA           v   COPY public.users_poxter (id_u, name_u, lastname_u, email_u, area_u, password_u, username_u, telephone_u) FROM stdin;
    public          postgres    false    216   ]       &           2606    16486 $   patients_poxter patients_poxter_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public.patients_poxter
    ADD CONSTRAINT patients_poxter_pkey PRIMARY KEY (id_p);
 N   ALTER TABLE ONLY public.patients_poxter DROP CONSTRAINT patients_poxter_pkey;
       public            postgres    false    217            "           2606    16463 &   surveys_patients surveys_patients_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public.surveys_patients
    ADD CONSTRAINT surveys_patients_pkey PRIMARY KEY (id_survey);
 P   ALTER TABLE ONLY public.surveys_patients DROP CONSTRAINT surveys_patients_pkey;
       public            postgres    false    215            $           2606    16481    users_poxter users_poxter_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.users_poxter
    ADD CONSTRAINT users_poxter_pkey PRIMARY KEY (id_u);
 H   ALTER TABLE ONLY public.users_poxter DROP CONSTRAINT users_poxter_pkey;
       public            postgres    false    216            �   �   x�]�MN�0��/��	P��N��B+�FBa�fHG�(���,ȍXt�r1\@u=�?���\~k�ţ�w�yKa\N�g��@��R��:�I�i
��@!�)`jl���|.�r����ߦ��OO��R���vv��5T�2B
YJ���.��L�u����~��8s�Uڔ�����@�ˉ��H1�Q�� D%��l�7K��6u������4�G�o$Ժ��J-R�����h}r��b��bOWY�}PAn+      �   /   x�3�4202�5��52�,(*MMJTHIUH�K.M-.IBB\1z\\\ ��G�      �   �   x�]�Kj�@D׭S�b���ŉW�@ �lzzz���c�P9G.aC )(�x�*������]���y'���g�l�4\�������=1�EJ�l�D�L4�$`���=a�R,�6�(��R�'��� X����a]o��(�L�3�&���p�2Sz��x�[mW�� >y���>e�
SvYD�\�#E��v)!�.�J�!E�@y��?�>���~ vAY�     