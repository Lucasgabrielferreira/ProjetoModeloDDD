<h1>ProjetoModeloDDD</h1>

<p><strong>ProjetoModeloDDD</strong> é uma aplicação ASP.NET MVC baseada nos princípios de <strong>Domain-Driven Design (DDD)</strong>, que implementa operações de <strong>CRUD</strong> (Create, Read, Update, Delete) para <strong>Clientes</strong> e <strong>Produtos</strong>. A arquitetura do projeto está estruturada em camadas, utilizando <strong>Entity Framework</strong> para acesso a dados e <strong>AutoMapper</strong> para mapear entre ViewModels e Entidades de Domínio.</p>

<h2>Índice</h2>
<ul>
  <li><a href="#visao-geral">Visão Geral</a></li>
  <li><a href="#estrutura-do-projeto">Estrutura do Projeto</a></li>
  <li><a href="#funcionalidades">Funcionalidades</a></li>
  <li><a href="#tecnologias-utilizadas">Tecnologias Utilizadas</a></li>
  <li><a href="#instalacao">Instalação</a></li>
  <li><a href="#configuracao">Configuração</a></li>
  <li><a href="#uso">Uso</a></li>
  <li><a href="#contribuicoes">Contribuições</a></li>
  <li><a href="#licenca">Licença</a></li>
</ul>

<h2 id="visao-geral">Visão Geral</h2>
<p>O <strong>ProjetoModeloDDD</strong> segue uma arquitetura em camadas, focada em <strong>DDD</strong>, e promove a separação de responsabilidades entre as camadas de <strong>Apresentação</strong>, <strong>Aplicação</strong>, <strong>Domínio</strong> e <strong>Infraestrutura</strong>. Ele utiliza <strong>AutoMapper</strong> para realizar o mapeamento entre os <strong>ViewModels</strong> usados na interface e as <strong>Entidades de Domínio</strong> que representam a lógica de negócio.</p>

<h2 id="estrutura-do-projeto">Estrutura do Projeto</h2>
<p>A solução é organizada nas seguintes camadas:</p>
<ul>
  <li><strong>ProjetoModeloDDD.Mvc</strong>: Camada de apresentação (ASP.NET MVC) responsável por lidar com a interface do usuário e os controladores.</li>
  <li><strong>ProjetoModeloDDD.Application</strong>: Camada de aplicação que faz a ponte entre as camadas de apresentação e de domínio. Contém os serviços de aplicação.</li>
  <li><strong>ProjetoModeloDDD.Domain</strong>: Camada de domínio, contendo as entidades de negócio, serviços de domínio e interfaces de repositório.</li>
  <li><strong>ProjetoModeloDDD.Infra.Data</strong>: Camada de infraestrutura responsável pelo acesso ao banco de dados utilizando o <strong>Entity Framework</strong>.</li>
</ul>

<h2 id="funcionalidades">Funcionalidades</h2>
<ul>
  <li><strong>CRUD de Clientes e Produtos</strong>: O sistema permite criar, ler, atualizar e deletar clientes e produtos.</li>
  <li><strong>Listagem de Clientes Especiais</strong>: Implementação de regras de negócio para listar clientes especiais.</li>
  <li><strong>Mapeamento Automático com AutoMapper</strong>: Mapeia automaticamente entre <strong>ViewModels</strong> e <strong>Entidades de Domínio</strong>.</li>
  <li><strong>Injeção de Dependência com Ninject</strong>: Facilita a gestão de dependências entre as camadas do projeto.</li>
</ul>

<h2 id="tecnologias-utilizadas">Tecnologias Utilizadas</h2>
<ul>
  <li><strong>ASP.NET MVC 5</strong>: Framework para construir a aplicação web.</li>
  <li><strong>Entity Framework 6</strong>: ORM para gerenciamento do banco de dados.</li>
  <li><strong>AutoMapper (versão antiga)</strong>: Biblioteca para mapear objetos entre diferentes camadas.</li>
  <li><strong>Ninject</strong>: Para injeção de dependência.</li>
  <li><strong>SQL Server LocalDb</strong>: Banco de dados utilizado na aplicação.</li>
</ul>

<h2 id="instalacao">Instalação</h2>

<h3>Requisitos</h3>
<ul>
  <li><a href="https://visualstudio.microsoft.com/">Visual Studio</a> 2019 ou superior.</li>
  <li><strong>.NET Framework 4.8</strong> ou superior.</li>
  <li><strong>SQL Server LocalDb</strong> (padrão no Visual Studio).</li>
  <li><strong>NuGet</strong> para gerenciar pacotes.</li>
</ul>

<h3>Passos para Instalação</h3>
<ol>
  <li>Clone o repositório para a sua máquina local:
    <pre><code>git clone https://github.com/seu-usuario/ProjetoModeloDDD.git</code></pre>
  </li>
  <li>Abra a solução <strong>ProjetoModeloDDD.sln</strong> no Visual Studio.</li>
  <li>Restaure os pacotes NuGet:
    <ul>
      <li>No Visual Studio, vá para <strong>Tools</strong> &gt; <strong>NuGet Package Manager</strong> &gt; <strong>Manage NuGet Packages for Solution</strong> e clique em <strong>Restore</strong>.</li>
    </ul>
  </li>
  <li>Compile a solução.</li>
</ol>

<h2 id="configuracao">Configuração</h2>

<h3>Banco de Dados</h3>
<p>A aplicação usa <strong>LocalDb</strong> por padrão. O arquivo de configuração de banco de dados está localizado no arquivo <strong>web.config</strong> da camada <strong>ProjetoModeloDDD.Mvc</strong>. Certifique-se de que o <strong>LocalDb</strong> está instalado e funcionando no seu ambiente de desenvolvimento.</p>

<pre><code>&lt;connectionStrings&gt;
  &lt;add name="ProjetoModeloDDD" 
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjetoModeloDB.mdf;Initial Catalog=ProjetoModeloDB;Integrated Security=True" 
       providerName="System.Data.SqlClient" /&gt;
&lt;/connectionStrings&gt;
</code></pre>

<p>Se você quiser usar uma instância completa do SQL Server, modifique a string de conexão conforme necessário.</p>

<h3>Configuração do AutoMapper</h3>
<p>O <strong>AutoMapper</strong> está configurado com dois perfis:</p>
<ul>
  <li><strong>ViewModelToDomainMappingProfile</strong>: Mapeia ViewModels para Entidades de Domínio.</li>
  <li><strong>DomainToViewModelMappingProfile</strong>: Mapeia Entidades de Domínio para ViewModels.</li>
</ul>

<pre><code>public class AutoMapperConfig
{
    public static void RegisterMappings()
    {
        Mapper.Initialize(cfg =&gt;
        {
            cfg.AddProfile&lt;ViewModelToDomainMappingProfile&gt;();
            cfg.AddProfile&lt;DomainToViewModelMappingProfile&gt;();
        });
    }
}
</code></pre>

<h3>Injeção de Dependência</h3>
<p>A injeção de dependência é gerenciada com o <strong>Ninject</strong>. A classe <strong>NinjectWebCommon.cs</strong> no diretório <strong>App_Start</strong> configura as dependências entre os serviços e repositórios.</p>

<h2 id="uso">Uso</h2>
<ol>
  <li>Compile e execute a aplicação no Visual Studio (pressione <strong>F5</strong>).</li>
  <li>Acesse a aplicação pelo navegador (geralmente em <code>http://localhost:xxxx</code>).</li>
  <li>Use as páginas para gerenciar clientes e produtos.</li>
</ol>

<h3>Funcionalidades de CRUD</h3>
<ul>
  <li><strong>Clientes</strong>: Criar, listar, editar e remover clientes.</li>
  <li><strong>Produtos</strong>: Criar, listar, editar e remover produtos.</li>
  <li><strong>Clientes Especiais</strong>: Listar clientes que atendem a critérios especiais.</li>
</ul>

<h2 id="contribuicoes">Contribuições</h2>
<p>Contribuições são bem-vindas! Se você deseja melhorar este projeto, siga os passos:</p>
<ol>
  <li>Fork o projeto.</li>
  <li>Crie uma branch com suas alterações: <code>git checkout -b minha-feature</code>.</li>
  <li>Faça commit das suas alterações: <code>git commit -m 'Minha nova feature'</code>.</li>
  <li>Envie suas alterações: <code>git push origin minha-feature</code>.</li>
  <li>Abra um Pull Request.</li>
</ol>

<h2 id="licenca">Licença</h2>
<p>Este projeto é licenciado sob a <a href="https://github.com/Lucasgabrielferreira">Lucas Gabriel Ferreira</a>.</p>
