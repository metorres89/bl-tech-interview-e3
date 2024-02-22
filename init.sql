-- Table: public.book

DROP TABLE IF EXISTS public.book;

CREATE TABLE IF NOT EXISTS public.book
(
    id serial NOT NULL,
    title character varying(100) COLLATE pg_catalog."default" NOT NULL,
	author character varying(100) COLLATE pg_catalog."default" NOT NULL,
    isbn character varying(17) COLLATE pg_catalog."default" NOT NULL,
    create_date timestamp with time zone DEFAULT current_timestamp NOT NULL,
    create_user character varying(255) COLLATE pg_catalog."default" DEFAULT current_user NOT NULL,
    update_date timestamp with time zone,
    update_user character varying(255) COLLATE pg_catalog."default",
    CONSTRAINT book_pkey PRIMARY KEY (id)
);

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.book
    OWNER to postgres;


INSERT INTO public.book (title, author, isbn, created_date, created_user)
VALUES ('The Great Gatsby', 'F. Scott Fitzgerald', '978-3-16-148410-0', '2022-02-21T12:00:00Z', 'app');

INSERT INTO public.book (title, author, isbn, created_date, created_user)
VALUES ('To Kill a Mockingbird', 'Harper Lee', '978-0-06-112008-4', '2022-02-21T12:30:00Z', 'app');

INSERT INTO public.book (title, author, isbn, created_date, created_user)
VALUES ('1984', 'George Orwell', '978-0-452-28423-4', '2022-02-21T13:00:00Z', 'app');