# Projeto para o estudo de SOLID com .NET

Refatoração de um código aplicando principios do S.O.L.I.D e outras conveções.

### S.O.L.I.D

- SRP (Single Responsiblity Principle): "Uma classe deve ter um, e somente um, motivo para mudar."

- OCP (Open-Closed Principle): "Objetos ou entidades devem estar abertos para extensão, mas fechados para modificação."

- LSP (Liskov Substitution Principle): "As classes base devem ser substituíveis por suas classes derivadas."

- ISP (Interface Segregation Principle): "Muitas interfaces específicas são melhores do que uma interface única."

- DIP (Dependency Inversion Principle): "Dependa de uma abstração e não de uma implementação."

### Outros termos e teorias estudados

- Princípio DRY (Dont repeat yourself)
- Single Source of Truth
- Clean/Onion Architecture

### Ações realizadas:

- Refatoração de controllers extraindo destes os métodos de manipulação do Database para uma classe DAO (DataAcessObject), com objetivo de retirar esta responsabilidade das classes em questão e evitar repetição de código [SRP];

- Implementação de Injeção de dependência com ILeilaoDAO, diminuindo o acoplamento dos controllers e proporcionando maior estabilidade do software com a inverção de dependência [DIP];

- Criação de camada de negócios para centralização de casos de uso [SRP + DIP];

- Implementação de classes mais especificas substituindo implementações default, com o objetivo de se seguir o principio [OCP + LSP];

- Refatoração das interfaces DAO, definindo interfaces mais especificas e garantindo a total implementação das abstrações propostas [ISP];
