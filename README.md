# Desafio Hummer (Backend)

Aplicativo para organização de eventos (Churrasco), feito em ASP.Net Core 3.

## Instalação e Configurações

É necessário ter instalado os seguintes pacotes:

* Asp Net Core SDK 3.1;
* SQL Server (Express ou Development).

Configurações:

* Ter configurado um banco de dados chamado barbecuedb;
* No arquivo appsetting.json é possível alterar as informações do banco e credenciais:

```bash
  "SqlConnection": {
    "SqlConnectionString": "Server=SERVERNAME;Database=NAMEBD;Trusted_Connection=True"
  }
```


## License
[MIT](https://choosealicense.com/licenses/mit/)
