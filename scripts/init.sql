-- Topologia: Blocos
CREATE TABLE "Bloco" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(100) NOT NULL,
    "Descricao" VARCHAR(255) NULL
);

-- Topologia: Salas (Vinculadas a um Bloco)
CREATE TABLE "Sala" (
    "Id" UUID PRIMARY KEY,
    "BlocoId" UUID NOT NULL,
    "Nome" VARCHAR(100) NOT NULL,
    "Tipo" VARCHAR(50) NULL,
    CONSTRAINT "FK_Sala_Bloco" FOREIGN KEY ("BlocoId") REFERENCES "Bloco" ("Id") ON DELETE CASCADE
);

-- Domínio: Insumos
CREATE TABLE "Insumo" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(150) NOT NULL,
    "UnidadeMedida" VARCHAR(20) NOT NULL,
    "QuantidadeDisponivel" DECIMAL(10, 2) NOT NULL DEFAULT 0,
    "EstoqueMinimo" DECIMAL(10, 2) NOT NULL DEFAULT 0
);