-- ===== MilasAppDB =====
CREATE DATABASE "milas_app_db"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- ========== TABLES ===============================

-- ===== User =====
CREATE TABLE public."user"
(
    "id" uuid NOT NULL,
    "username" varchar(30) NOT NULL,
    "password" varchar(100) NOT NULL,
    "email" varchar(50) NOT NULL,
    "is_active" boolean NOT NULL,
    CONSTRAINT "user_id-pkey" PRIMARY KEY ("id")
);
ALTER TABLE IF EXISTS public."user" OWNER to "postgres";

-- ===== Units of Measure =====
CREATE TABLE public."uoms"
(
    "id" uuid NOT NULL,
    "unit" varchar(30) NOT NULL,
    "is_active" boolean NOT NULL,
    CONSTRAINT "uoms_id-pkey" PRIMARY KEY ("id")
);
ALTER TABLE IF EXISTS public."uoms" OWNER to "postgres";

-- ===== Suplies Own Products =====
CREATE TABLE public."supplies"
(
    "id" uuid NOT NULL,
    "name" varchar(30) NOT NULL,
    "quantity" real NOT NULL,
    "uom_id" uuid NOT NULL,
    "cost_price" money NOT NULL,
    "yeild" integer NOT NULL,
    "is_active" boolean NOT NULL,
    CONSTRAINT "supplies_id-pkey" PRIMARY KEY ("id"),
    CONSTRAINT "uoms-supplies-uom_id-fkey" FOREIGN KEY ("uom_id") REFERENCES public."uoms" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."supplies" OWNER to "postgres";

-- ===== Products =====
CREATE TABLE public."products"
(
    "id" uuid NOT NULL,
    "name" varchar(30) NOT NULL,
    "is_own" boolean NOT NULL,
    "cost_price" money NOT NULL,
    "sale_price" money NOT NULL,
    "is_active" boolean NOT NULL,
    CONSTRAINT "products_id-pkey" PRIMARY KEY ("id")
);
ALTER TABLE IF EXISTS public."products" OWNER to "postgres";

-- ===== Product Supplies =====
CREATE TABLE public."product_supplies"
(
    "product_id" uuid NOT NULL,
    "supply_id" uuid NOT NULL,
    CONSTRAINT "product_id-supply_id-pkey" PRIMARY KEY ("product_id", "supply_id"),
    CONSTRAINT "supplies-product_supplies-supply_id-fkey" FOREIGN KEY ("supply_id") REFERENCES public."supplies" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "products-product_supplies-product_id-fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."product_supplies" OWNER to "postgres";

-- ===== Kioscos =====
CREATE TABLE public."kioscos"
(
    "id" uuid NOT NULL,
    "name" varchar(50) NOT NULL,
    "manager" varchar(50) NOT NULL,
    "phone" varchar(30) NOT NULL,
    "address" varchar(100) NOT NULL,
    "user_id" uuid NOT NULL,
    "is_enable_changes" boolean NOT NULL,
    "notes" varchar(1000) NOT NULL,
    "dubt" money NOT NULL,
    "order" uuid NOT NULL,
    "is_active" boolean NOT NULL,
    CONSTRAINT "kioscos_id-pkey" PRIMARY KEY ("id"),
    CONSTRAINT "user-kioscos-user_id-fkey" FOREIGN KEY ("user_id") REFERENCES public."user" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."kioscos" OWNER to "postgres";

-- ===== Kiosco Products =====
CREATE TABLE public."kiosco_products"
(
    "kiosco_id" uuid NOT NULL,
    "product_id" uuid NOT NULL,
    "kiosco_price" money NOT NULL,
    "stock" integer NOT NULL,
    CONSTRAINT "kiosco_id-product_id-pkey" PRIMARY KEY ("kiosco_id", "product_id"),
    CONSTRAINT "products-kiosco_products-product_id-fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "kioscos-kiosco_products-kiosco_id-fkey" FOREIGN KEY ("kiosco_id") REFERENCES public."kioscos" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."kiosco_products" OWNER to "postgres";

-- ===== Visits =====
CREATE TABLE public."visits"
(
    "id" uuid NOT NULL,
    "kiosco_id" uuid NOT NULL,
    "date" timestamp NOT NULL,
    CONSTRAINT "visits_id-pkey" PRIMARY KEY ("id"),
    CONSTRAINT "kioscos-visits-kiosco_id-fkey" FOREIGN KEY ("kiosco_id") REFERENCES public."kioscos" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."visits" OWNER to "postgres";

-- ===== Visit Details =====
CREATE TABLE public."visit_details"
(
    "id" uuid NOT NULL,
    "visit_id" uuid NOT NULL,
    "product_id" uuid NOT NULL,
    "has" integer NOT NULL,
    "leave" integer NOT NULL,
    "changes" integer NOT NULL,
    "sold" integer NOT NULL,
    "hist_sale_price" money NOT NULL,
    CONSTRAINT "visit_details_id-pkey" PRIMARY KEY ("id"),
    CONSTRAINT "visits-visit_details-visit_id-fkey" FOREIGN KEY ("visit_id") REFERENCES public."visits" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT "products-visit_details-product_id-fkey" FOREIGN KEY ("product_id") REFERENCES public."products" ("id") MATCH FULL ON UPDATE NO ACTION ON DELETE NO ACTION
);
ALTER TABLE IF EXISTS public."visit_details" OWNER to "postgres";


