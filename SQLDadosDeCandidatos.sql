/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[Nome]
      ,[Email]
      ,[Instituicao]
      ,[Conclusao]
      ,[Curso]
      ,[Status]
      ,[Telefone]
      ,[Linkedin]
      ,[DataNascimento]
      ,[Cidade]
      ,[Senha]
  FROM [inscricoes].[dbo].[CandidatoEntidade]

  update CandidatoEntidade
  set Nome = 'Daniel' where id = 5;

  insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Anna', 'ana@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');


    insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Cesar', 'cesar@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');
      insert into CandidatoEntidade

  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Carol', 'Carol@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

    insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Andre', 'Andre@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

      insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Jonatan', 'Jonatan@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

        insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Regis', 'Regis@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

        insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Mateus', 'mateus@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

        insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Cassio', 'cassio@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

          insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('victor', 'victor@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

            insert into CandidatoEntidade
  (Nome, Email, Instituicao, Conclusao, Curso, Status)
  values
  ('Henrique', 'Henrique@hotmail.com', 'Unisinos', 25/12/1992, 'Ciencias da computação', 'Inicial');

    insert into AdministradorEntidade
  (Email, Senha, Nome)
  values
  ('rodrigo.scheuer@hotmail.com', '2e247e2eb505c42b362e80ed4d05b078', 'Rodrigo Scheuer');

