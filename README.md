# BankReleases
BankReleasesApp

### Account - Microservice de contas

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
          Arrumarr
        }
```

Para atualizar uma conta corrente:
```ruby
[Put]
http://localhost:5000/api/checking-account/{accountId}/

Body => {
          Arrumarr
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
          Arrumarr
        }
```

Para atualizar um usuário:
```ruby
[Put]
http://localhost:5000/api/user/{userId}/

Body => {
          Arrumarr
        }
```

Para deletar um usuário:
```ruby
[Delete]
http://localhost:5000/api/user/{userId}/
```


### BankReleases - Microservice de lançamentos

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
