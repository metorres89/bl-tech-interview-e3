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

--TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.book
    OWNER to postgres;

-- Table: public.user

DROP TABLE IF EXISTS public.user;

CREATE TABLE public.user (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(100) NOT NULL,
    create_date TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    create_user VARCHAR(255) NOT NULL,
    update_date TIMESTAMPTZ,
    update_user VARCHAR(255)
);

--TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.user
    OWNER to postgres;

-- Insert some sample books
INSERT INTO public.book (title, author, isbn, create_date, create_user)
VALUES ('Songs of a Dead Dreamer and Grimscribe', 'Thomas Ligotti', '978-0143107767', '2024-02-21T12:00:00Z', 'app');

INSERT INTO public.book (title, author, isbn, create_date, create_user)
VALUES ('Leaves of Grass', 'Walt Whitman', '979-8886000931', '2024-02-21T12:30:00Z', 'app');

INSERT INTO public.book (title, author, isbn, create_date, create_user)
VALUES ('Stranger Things Happen: Stories', 'Kelly Link', '978-1931520003', '2024-02-21T13:00:00Z', 'app');

-- Insert some sample users
INSERT INTO public.user (first_name, last_name, email, password, create_user)
VALUES ('Pedro', 'Pedrini', 'pedro.pedrini@example.com', 'password123', 'app');

INSERT INTO public.user (first_name, last_name, email, password, create_user)
VALUES ('Maria', 'Merlo', 'maria.merlo@example.com', 'password123', 'app');
