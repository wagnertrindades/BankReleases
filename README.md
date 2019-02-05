# BankReleases

![image](https://user-images.githubusercontent.com/16762195/52282034-88bc4480-2946-11e9-99c6-43c7c1ce7dbc.png)

### BankRelease - Microservice de lançamentos
>Microserviço responsável pelos lançamentos que neste caso foi implementado o lançamento de transferência.

Nesse microserviço foi implementado a possibilidade de buscar todas as transferências, criar uma transferência e consultar uma transferência.

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

Nesse microserviço foi implementado a possibilidade de buscar todas as contas correntes, criar uma conta corrente, consultar uma conta corrente, atualizar uma conta corrente, deletar uma conta corrente, fazer o débito de determinado valor em uma conta corrente e fazer o crédito de determinado valor em uma conta corrente.

Também foi implementado os usuários que cada conta corrente pertence a um usuário e neles as operações de buscar todos os usuários, criar um usuário, consultar um usuário, atualizar e deletar um usuário. 

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
