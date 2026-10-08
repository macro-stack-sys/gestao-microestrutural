#!/bin/bash

echo "=========================================================="
echo " GESTÃO MICROESTRUTURAL - Automação de Migrações (EF Core)"
echo "=========================================================="

# Fail-fast: garante que a CLI do .NET está disponível no SO antes de prosseguir
command -v dotnet >/dev/null 2>&1 || { echo >&2 "Erro: .NET CLI não instalada. Abortando."; exit 1; }

cd ../src/backend || { echo >&2 "Erro: Pasta src/backend não encontrada."; exit 1; }

echo "[INFO] Restaurando ferramentas locais do .NET..."
dotnet tool restore

echo "[INFO] Aplicando migrações do Read Model (TopologiaDbContext)..."

# Decisão Arquitetural: O Entity Framework assume o controle exclusivo do schema de leitura.
# O banco do Event Store (Write Model) é intocável e governado apenas por scripts manuais.
dotnet ef database update --context TopologiaDbContext --project GestaoMicroestrutural.Infrastructure --startup-project GestaoMicroestrutural.Api

echo "=========================================================="
echo " Migrações do Read Model aplicadas com sucesso!           "
echo "=========================================================="