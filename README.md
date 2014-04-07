MinuTrade
=========

Teste para MinuTrade

Lucas e Hugo,

Só tive tempo para criar a solução hoje, 07/04, mas basicamente consite em:
- Um banco de dados de teste em SQL Server Compact;
- Uma biblioteca (DLL), para abstrair a camada de acesso à dados;
- Um serviço WCF para comunicação com o banco de dados e expõe métodos para atender os requisitos;
- Um cliente em ASP.NET MVC 4, que consome o serviço e as funções básicas.

O que deveria ser implementado, mas não foi por falta de tempo:
- Criar um provedor de credenciais no lado da EmpresaXYZ para expor de maneira segura o serviço WCF;
- Proteger o serviço WCF com autenticação e protocolo HTTPS;
- Implementar no serviço WCF o suporte à JSON para melhorar a interoperabilidade, incluindo clientes mobile, por exemplo;
- Implementar na aplicação cliente o gerenciamento de identidades, viabilizando o uso do serviço já protegido;
- Melhorar a aplicação cliente ASP.NET MVC quanto navegação, layout, etc e criar outras aplicações cliente usando da exposição do serviço no formato JSON.

Qualquer dúvida, entre em contato.

