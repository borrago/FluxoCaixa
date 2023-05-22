set "diretorio_atual=%CD%"

docker compose up -d

start "FluxoCaixa" http://localhost:8080/
