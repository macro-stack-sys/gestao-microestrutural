-- Criação do Schema de Leitura
CREATE SCHEMA IF NOT EXISTS "Topologia";

-- Topologia: Blocos
CREATE TABLE "Topologia"."Bloco" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(100) NOT NULL,
    "Descricao" VARCHAR(255) NULL
);

-- Topologia: Salas
CREATE TABLE "Topologia"."Sala" (
    "Id" UUID PRIMARY KEY,
    "BlocoId" UUID NOT NULL,
    "Nome" VARCHAR(100) NOT NULL,
    "Tipo" VARCHAR(50) NOT NULL,
    CONSTRAINT "FK_Sala_Bloco" FOREIGN KEY ("BlocoId") REFERENCES "Topologia"."Bloco" ("Id") ON DELETE CASCADE
);

-- Domínio: Insumos
CREATE TABLE "Topologia"."Insumo" (
    "Id" UUID PRIMARY KEY,
    "TenantId" VARCHAR(50) NOT NULL,
    "Descricao" VARCHAR(255) NOT NULL,
    "Patrimonio" VARCHAR(100) NULL,
    "Natureza" TEXT NOT NULL,
    "Status" TEXT NOT NULL,
    "Tipo" VARCHAR(100) NOT NULL,
    "UnidadeMedida" VARCHAR(20) NOT NULL,
    "EstoqueMinimo" DECIMAL(18, 2) NOT NULL DEFAULT 0,
    "QuantidadeDisponivel" DECIMAL(18, 2) NOT NULL DEFAULT 0
);