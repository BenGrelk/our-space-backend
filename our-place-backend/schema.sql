SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;
SET default_tablespace = '';
SET default_table_access_method = heap;

CREATE TABLE public.canvas
(
    canvas_id  integer                     NOT NULL,
    created_at timestamp without time zone NOT NULL,
    width      integer,
    height     integer
);

CREATE TABLE public.channels
(
    channel_id         integer NOT NULL,
    channel_name       text    NOT NULL,
    description        text,
    created_at         timestamp without time zone,
    icon               bytea,
    created_by_user_id integer
);

CREATE TABLE public.direct_messages
(
    request_user_id  integer NOT NULL,
    response_user_id integer NOT NULL,
    message_text     text    NOT NULL,
    attachment       bytea
);

CREATE TABLE public.follows
(
    follow_id                integer NOT NULL,
    request_user_id          integer NOT NULL,
    response_user_id         integer NOT NULL,
    request_follows_response boolean
);

CREATE TABLE public.pixels
(
    pixel_id  integer NOT NULL,
    user_id   integer,
    canvas_id integer
);

CREATE TABLE public.post_reactions
(
    post_id          integer NOT NULL,
    post_reaction_id integer NOT NULL,
    user_id          integer NOT NULL,
    reaction_id      integer
);

CREATE TABLE public.posts
(
    post_id         integer NOT NULL,
    creator_user_id integer NOT NULL,
    channel_id      integer,
    attachment      bytea,
    message         text,
    created_at      timestamp without time zone
);

CREATE TABLE public.reaction_types
(
    reaction_type_id integer NOT NULL,
    reaction_text    text,
    reaction_emoji   text
);

CREATE TABLE public.users
(
    user_id         integer                     NOT NULL,
    username        text                        NOT NULL,
    profile_picture bytea,
    created_at      timestamp without time zone NOT NULL,
    password        text                        NOT NULL,
    display_name    text,
    status          text,
    description     text,
    settings        json,
    banner          integer
);

INSERT INTO public.users
VALUES (1, 'admin', NULL, '2019-01-01 00:00:00', 'admin', NULL, 'active', NULL, NULL, NULL);

ALTER TABLE ONLY public.canvas
    ADD CONSTRAINT canvas_pk PRIMARY KEY (canvas_id);

ALTER TABLE ONLY public.channels
    ADD CONSTRAINT channels_pk PRIMARY KEY (channel_id);

ALTER TABLE ONLY public.direct_messages
    ADD CONSTRAINT direct_messages_pk PRIMARY KEY (request_user_id, response_user_id);

ALTER TABLE ONLY public.follows
    ADD CONSTRAINT follows_pk PRIMARY KEY (follow_id);

ALTER TABLE ONLY public.pixels
    ADD CONSTRAINT pixels_pk PRIMARY KEY (pixel_id);

ALTER TABLE ONLY public.post_reactions
    ADD CONSTRAINT post_reactions_pk PRIMARY KEY (post_reaction_id);

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pk PRIMARY KEY (post_id);

ALTER TABLE ONLY public.reaction_types
    ADD CONSTRAINT reaction_types_pk PRIMARY KEY (reaction_type_id);

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pk PRIMARY KEY (user_id);

CREATE INDEX posts_message_index ON public.posts USING btree (message);

ALTER TABLE ONLY public.channels
    ADD CONSTRAINT channels_users_userid_fk FOREIGN KEY (created_by_user_id) REFERENCES public.users (user_id);

ALTER TABLE ONLY public.direct_messages
    ADD CONSTRAINT direct_messages_users_userid_fk FOREIGN KEY (request_user_id) REFERENCES public.users (user_id);

ALTER TABLE ONLY public.direct_messages
    ADD CONSTRAINT direct_messages_users_userid_fk_2 FOREIGN KEY (response_user_id) REFERENCES public.users (user_id);

ALTER TABLE ONLY public.follows
    ADD CONSTRAINT follows_users_userid_fk FOREIGN KEY (request_user_id) REFERENCES public.users (user_id);

ALTER TABLE ONLY public.follows
    ADD CONSTRAINT follows_users_userid_fk_2 FOREIGN KEY (response_user_id) REFERENCES public.users (user_id);

ALTER TABLE ONLY public.pixels
    ADD CONSTRAINT pixels_canvas_canvasid_fk FOREIGN KEY (canvas_id) REFERENCES public.canvas (canvas_id);

ALTER TABLE ONLY public.pixels
    ADD CONSTRAINT pixels_users_userid_fk FOREIGN KEY (user_id) REFERENCES public.users (user_id);

ALTER TABLE ONLY public.post_reactions
    ADD CONSTRAINT post_reactions_posts_postid_fk FOREIGN KEY (post_id) REFERENCES public.posts (post_id);

ALTER TABLE ONLY public.post_reactions
    ADD CONSTRAINT post_reactions_reaction_types_reactiontypeid_fk FOREIGN KEY (reaction_id) REFERENCES public.reaction_types (reaction_type_id);

ALTER TABLE ONLY public.post_reactions
    ADD CONSTRAINT post_reactions_users_userid_fk FOREIGN KEY (user_id) REFERENCES public.users (user_id);

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts___fk FOREIGN KEY (channel_id) REFERENCES public.channels (channel_id);

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_users_userid_fk FOREIGN KEY (creator_user_id) REFERENCES public.users (user_id);