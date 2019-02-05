# BankReleases

![image](https://user-images.githubusercontent.com/16762195/52282034-88bc4480-2946-11e9-99c6-43c7c1ce7dbc.png)

### Setup para subir o projeto localmente

Após clonar o projeto para sua máquina local deve seguir os seguintes passos:

- Configurar APIGateway para não rodar pelo IIS Express

	- Selecionar o APIGateway

 	![image](https://user-images.githubusercontent.com/16762195/52290892-456ad180-2958-11e9-97d0-768fa713ffa3.png)

 	- Selecionar o play com API Gateway

 	![image](https://user-images.githubusercontent.com/16762195/52291052-a4304b00-2958-11e9-86aa-da7d86d31e3a.png)
	
- Configurar o projeto para rodar todos os microservices e o API Gateway

	- Clique com o botão direito na solução do projeto na Solution Explorer e em Set StartUp Projects
	
	<img src="https://user-images.githubusercontent.com/16762195/52291263-20c32980-2959-11e9-881b-27869d270760.png" alt="image" style="max-width:100%;" width="350" height="450">

	- Selecione Multiple startup projects e os seguintes projetos devem estar com Start selecionado:
		- Account.Api
		- APIGateway
		- BankRelease.Api
		
	<img src="https://user-images.githubusercontent.com/16762195/52291509-a941ca00-2959-11e9-8c72-3003f9a65737.png" alt="image" style="max-width:100%;" width="600" height="400">

### BankRelease - Microservice de lançamentos
>Microserviço responsável pelos lançamentos que neste caso foi implementado o lançamento de transferência.

Nesse microserviço foram implementadas as seguintes operações:
- Buscar todas as transferências
- Criar uma transferência
- Consultar uma transferência

Na operação de criar uma transferência é feita a comunicação com o microserviço de contas via http request de débito na conta de origin e crédito na conta de destino.

**Endpoints de lançamentos de transferência**

Para ver todos os lançamentos de transferência:
```ruby
[Get]
http://localhost:5000/api/transfer-release/
```
Para criar um lançamento de transferência:
```ruby
[Post]
http://localhost:5000/api/transfer-release/

Body => {
          "originAccount": 1,
          "destinationAccount": 2,
          "value": 100.00
        }
```

Para consultar apenas um lançamento de transferência:
```ruby
[Get]
http://localhost:5000/api/transfer-release/{transferReleaseId}/
```

### Account - Microservice de contas
>Microserviço responsável pelas contas que nesse caso foi implementado as operações de conta corrente e usuário.

Nesse microserviço foram implementadas as seguintes operações:
- Buscar todas as contas correntes
- Criar uma conta corrente
- Consultar uma conta corrente
- Atualizar uma conta corrente
- Deletar uma conta corrente
- Fazer o débito de determinado valor em uma conta corrente
- Fazer o crédito de determinado valor em uma conta corrente

Também foi implementado os usuários que cada conta corrente pertence a um usuário e neles as operações:
- Buscar todos os usuários
- Criar um usuário
- Consultar um usuário
- Atualizar um usuário
- Deletar um usuário

**Endpoints das contas correntes**

Para consultar todas as contas correntes:
```ruby
[Get]
http://localhost:5000/api/checking-account/
```

Para consultar apenas uma conta corrente específica:
```ruby
[Get]
http://localhost:5000/api/checking-account/{accountId}/
```

Para criar uma conta corrente:
```ruby
[Post]
http://localhost:5000/api/checking-account/

Body => {
          "userId": 1
        }
```

Para atualizar uma conta corrente:
```ruby
[Put]
http://localhost:5000/api/checking-account/{accountId}/

Body => {
	"id": {accountId},
	"userId": 2
        }
```

Para deletar uma conta corrente:
```ruby
[Delete]
http://localhost:5000/api/checking-account/{accountId}/
```

Para fazer uma operação de débito em uma conta corrente:
```ruby
[Post]
http://localhost:5000/api/checking-account/{accountId}/debit

Body => {
          value: 100.55
        }
```

Para fazer uma operação de crédito em uma conta corrente:
```ruby
[Post]
http://localhost:5000/api/checking-account/{accountId}/credit

Body => {
          value: 100.55
        }
```

**Endpoints dos usuários**

Para consultar todos os usuários:
```ruby
[Get]
http://localhost:5000/api/user/
```

Para consultar apenas um usuário específico:
```ruby
[Get]
http://localhost:5000/api/user/{userId}/
```

Para criar um usuário:
```ruby
[Post]
http://localhost:5000/api/user/

Body => {
          "name": "Xunda",
          "cpf": "38304928043",
          "phone": "11998223344",
          "email": "xunda@gmail.com"
        }
```

Para atualizar um usuário:
```ruby
[Put]
http://localhost:5000/api/user/{userId}/

Body => {
          "id": {userId},
          "name": "Xunda da Silva",
          "cpf": "38304928043",
          "phone": "11998223344",
          "email": "xunda@gmail.com"
        }
```

Para deletar um usuário:
```ruby
[Delete]
http://localhost:5000/api/user/{userId}/
```
