-- ===== MilasAppDB =====
CREATE DATABASE "milas_app_db"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- ========== TABLES ===============================

-- ===== Units of Measure =====
CREATE TABLE public."uoms"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "unit" varchar(30) NOT NULL,
    "is_active" boolean NOT NULL,
    PRIMARY KEY ("id")
);
ALTER TABLE IF EXISTS public."uoms" OWNER to "postgres";

-- ===== Suplies Own Products =====
CREATE TABLE public."supplies"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "name" varchar(30) NOT NULL,
    "quantity" real NOT NULL,
    "uom_id" integer NOT NULL,
    "cost_price" money NOT NULL,
    "yeild" integer NOT NULL,
    "is_active" boolean NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "uoms_supplies-uom-id_fkey" FOREIGN KEY ("uom_id") REFERENCES public."uoms" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."supplies" OWNER to "postgres";

-- ===== Products =====
CREATE TABLE public."products"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "name" varchar(30) NOT NULL,
    "is_own" boolean NOT NULL,
    "cost_price" money NOT NULL,
    "sale_price" money NOT NULL,
    "is_active" boolean NOT NULL,
    PRIMARY KEY ("id")
);
ALTER TABLE IF EXISTS public."products" OWNER to "postgres";

-- ===== Supplies Product =====
CREATE TABLE public."supplies_product"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "supply_id" integer NOT NULL,
    "product_id" integer NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "supplies_supplies-product_supply-id_fkey" FOREIGN KEY ("supply_id") REFERENCES public."supplies" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "products_supplies-product_product-id_fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."supplies_product" OWNER to "postgres";

-- ===== History Products Prices =====
CREATE TABLE public."hist_prices"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "product_id" integer NOT NULL,
    "cost_price" money NOT NULL,
    "sale_price" money NOT NULL,
    "date" timestamp NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "products_hist-prices_product-id_fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."hist_prices" OWNER to "postgres";

-- ===== Roles =====
CREATE TABLE public."roles"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "name" varchar(30) NOT NULL,
    PRIMARY KEY ("id")
);
ALTER TABLE IF EXISTS public."roles" OWNER to "postgres";

-- ===== Workers =====
CREATE TABLE public."workers"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "name" varchar(50) NOT NULL,
    "phone" varchar(30) NOT NULL,
    "address" varchar(100) NOT NULL,
    "username" varchar(30) NOT NULL,
    "password" varchar(30) NOT NULL,
    "dubt" money NOT NULL,
    "role_id" integer NOT NULL,
    "is_active" boolean NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "roles_workers_role-id_fkey" FOREIGN KEY ("role_id") REFERENCES public."roles" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."workers" OWNER to "postgres";

-- ===== Products Worker =====
CREATE TABLE public."products_worker"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "product_id" integer NOT NULL,
    "worker_id" integer NOT NULL,
    "worker_price" money NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "products_products-worker_product-id_fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "kioscos_products-worker_worker-id_fkey" FOREIGN KEY ("worker_id") REFERENCES public."workers" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."products_worker" OWNER to "postgres";

-- ===== Orders =====
CREATE TABLE public."orders"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "worker_id" integer NOT NULL,
    "date" timestamp NOT NULL,
    "isConfirmed" boolean NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "workers_orders_worker-id_fkey" FOREIGN KEY ("worker_id") REFERENCES public."workers" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."orders" OWNER to "postgres";

-- ===== Order Details =====
CREATE TABLE public."order_details"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "order_id" integer NOT NULL,
    "product_id" integer NOT NULL,
    "quantity" integer NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "orders_order-details_order-id_fkey" FOREIGN KEY ("order_id") REFERENCES public."orders" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "products_order-details_product-id_fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."order_details" OWNER to "postgres";

-- ===== Kioscos =====
CREATE TABLE public."kioscos"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "name" varchar(50) NOT NULL,
    "manager" varchar(50) NOT NULL,
    "phone" varchar(30) NOT NULL,
    "address" varchar(100) NOT NULL,
    "is_enable_changes" boolean NOT NULL,
    "notes" varchar(1000) NOT NULL,
    "dubt" money NOT NULL,
    "is_active" boolean NOT NULL,
    PRIMARY KEY ("id")
);
ALTER TABLE IF EXISTS public."kioscos" OWNER to "postgres";

-- ===== Kioscos Worker =====
CREATE TABLE public."kioscos_worker"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "kiosco_id" integer NOT NULL,
    "worker_id" integer NOT NULL,
    "order" integer,
    "ends_at" timestamp,
    PRIMARY KEY ("id"),
    CONSTRAINT "kioscos_kioscos-worker_kiosco-id_fkey" FOREIGN KEY ("kiosco_id") REFERENCES public."kioscos" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "workers_kioscos-worker_worker-id_fkey" FOREIGN KEY ("worker_id") REFERENCES public."workers" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."kioscos_worker" OWNER to "postgres";

-- ===== Products Kiosco =====
CREATE TABLE public."products_kiosco"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "product_id" integer NOT NULL,
    "kiosco_id" integer NOT NULL,
    "stock" integer NOT NULL,
    "kiosco_price" money NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "products_products-kiosco_product-id_fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "kioscos_products-kiosco_kiosco-id_fkey" FOREIGN KEY ("kiosco_id") REFERENCES public."kioscos" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."products_kiosco" OWNER to "postgres";

-- ===== Visits =====
CREATE TABLE public."visits"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "kiosco_id" integer NOT NULL,
    "worker_id" integer NOT NULL,
    "date" timestamp NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "kioscos_visits_kiosco-id_fkey" FOREIGN KEY ("kiosco_id") REFERENCES public."kioscos" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "workers_visits_worker-id_fkey" FOREIGN KEY ("worker_id") REFERENCES public."workers" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."visits" OWNER to "postgres";

-- ===== Visit Details =====
CREATE TABLE public."visit_details"
(
    "id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "visit_id" integer NOT NULL,
    "product_id" integer NOT NULL,
    "has" integer NOT NULL,
    "leave" integer NOT NULL,
    "changes" integer NOT NULL,
    "sold" integer NOT NULL,
    "hist_sale_price" money NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT "visits_visit-details_visit-id_fkey" FOREIGN KEY ("visit_id") REFERENCES public."visits" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "products_visit-details_product-id_fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."visit_details" OWNER to "postgres";


