# Rust e Delphi — lowering portátil

## Autoridade

O backend C permanece o oráculo semântico para formas que ele consegue residualizar. Layouts rejeitados pelo C entram por uma ponte residual tipada e estrutural antes da normalização C. `compiler-session/source/PortableBackends.fs` continua sendo a autoridade do lowering Rust/Delphi; Runner e facade segmentada chamam o mesmo módulo. Construções não modeladas falham explicitamente, sem fallback silencioso. Quando o backend C ganhou `Sin` e `Cos`, a pipeline adaptativa recompilou o shard de codegen e os treze shards dependentes, preservando os demais como seeds canônicos.

## Direção arquitetural

O eixo principal é emissão nativa. A ABI tipada permanece como camada de interop e gate de regressão, não como proxy para layouts, closures, ciclos ou outras capacidades da linguagem.

A lane cobre escalares, controle, casts numéricos C explícitos e bounded, funções de primeira ordem, chamadas entre módulos Spiral, loops de cauda, SCCs homogêneos e heterogêneos, tuples, records, unions, arrays fixos e dinâmicos, aliases mutáveis, arrays aninhados, payloads gerenciados, strings UTF-8 orientadas a bytes, codepoint helpers, target items estruturados e interop externo registrado.

Rust usa `Rc`, `Rc<str>`, `Rc<RefCell<Vec<T>>>` e `Option<RecursiveN>`. Delphi usa `AnsiString`, arrays dinâmicos, classes recursivas e records tagueados com clone/drop explícito.

## Unicode pela superfície Spiral

A biblioteca compartilhada `samples/core/sm.spi` agora é a autoridade de decodificação escalar UTF-8, validação integral e fold genérico. `utf8_fold` segue o contrato maduro de coleções `estado -> escalar -> estado`, especializa o callback no call site e não materializa closure chamável nem coleção intermediária. A fixture positiva prova estado em tupla, hash sensível à ordem, string vazia e retomada válida; a negativa retoma no byte de continuação de `é` e precisa falhar em C, Rust e Delphi.

Os seis gates source-level fecham 30 identidades, 30 builds e 30 execuções: escalar, validação, fold, graphemes bounded, normalização bounded e equivalência canônica bounded. O contrato permanece deliberadamente limitado e não reivindica UAX #15 ou UAX #29 completos.

## Recursão terminal e SCCs

Funções self-tail elegíveis viram loops nativos. Componentes mutuamente recursivos viram dispatchers com estado estável. Todos os próximos argumentos são avaliados antes da substituição dos parâmetros, preservando a semântica simultânea da chamada.

SCCs heterogêneos usam uma união determinística de slots tipados. Slots escalares ausentes recebem defaults tipados. Strings, arrays e nominais recursivos usam liveness explícita.

Quando um nominal recursivo possui caso vazio, esse caso pode funcionar como sentinela real. Quando não possui, o backend emite uma opção verdadeira:

```text
Rust:   Option<RecursiveN>
Delphi: record HasValue: Boolean; Value: RecursiveN end
```

O Delphi fornece None, Some, Take, Clone e Drop. Ausência nunca é um union case inventado nem um handle vivo fictício.

As fixtures diretas executam profundidades de 999999 ou um milhão. `native_scc_multiple_tagged_recursive_slots` carrega dois slots recursivos opcionais independentes por três estados e retorna o payload esperado sem crescimento de pilha.

## Gate determinístico

`scripts/portable-backends-gate.sh` cobre 57 projetos canônicos, 171 identidades, 171 builds e 171 execuções. Após mudanças apenas no lowering, o modo abaixo reaplica a autoridade atual diretamente sobre os resíduos C canônicos:

```text
SPIRAL_GATE_DIRECT_RELOWER=1
SPIRAL_GATE_RUN_NEGATIVES=0
```

Rust e Delphi são comparados byte a byte, compilados e executados sem inicializar o supervisor. A lane SCC focada cobre 11 fixtures, 22 identidades, 33 builds e 33 execuções.

## Layouts tipados

A primeira ponte tipada reconhece `LayoutToStackMutable` escalar, mutação de record inteiro, `LayoutIndex` e consumo numérico final. Rust emite um `struct` local de stack; Delphi emite um `record` local. A fixture pública `native_layout_stack_mutable` fecha com código 15 nos dois backends, enquanto C preserva sua rejeição exata sem resíduo.

A ponte é deliberadamente estreita: ela reconhece a estrutura da linguagem, não o nome da fixture. Formas não reconhecidas continuam pelo pipeline anterior ou falham. `stack_refs` e `heap_refs` ainda exigem contratos explícitos de borrow, alias e não escape.

## Funções entre módulos e pacotes nativos

A fixture `native_multimodule` confirma resolução semântica através de módulos Spiral. O modo público `--lower-portable-package BACKEND INPUT.c OUTPUT_DIR` agora também separa o resíduo comprovado em fronteiras nativas reais.

No Rust, o pacote contém `Cargo.toml`, `src/lib.rs` e `src/main.rs`: tipos, helpers e a função receptora vivem na library crate; o binário constrói a closure, importa a crate e transporta o callable pela ligação nativa. No Delphi, `SpiralGeneratedUnit.pas` exporta os tipos e assinaturas, enquanto `main.pas` usa a unit e passa a closure pelo mesmo contrato.

`scripts/portable-callable-package-gate.sh` regenera e compara byte a byte os pacotes de `native_closure_transport` e `native_closure_recursive_capture`, executa Clippy/build/run no Rust e FPC/build/run no Delphi. A autoridade atual fecha quatro pacotes, quatro builds e quatro execuções, todos com resultado 42.

O passo restante não é inventar outra forma de callable: é ligar esse empacotador ao grafo real de packages/modules Spiral para emitir mais de uma biblioteca/unit derivada do programa, em vez da divisão canônica library+entrypoint.

## Target items e ABI

Target items estruturados aceitam `PRELUDE`, `BEFORE_MAIN` e `AFTER_MAIN`, deduplicam identidades e rejeitam conflitos. A ABI tipada preserva provas para escalares, UTF-8 emprestado, buffers const/mutáveis, agregados, callback estático `cdecl` e inteiro assinado de 64 bits. A fixture de `llabs` usa `-5000000000`, portanto uma implementação que estreite para 32 bits não consegue passar.

## Paridade com Lua e Gleam

Rust e Delphi ainda não ultrapassaram os backends Lua e Gleam no conjunto da linguagem. Na régua produtiva atual, Rust marca 695 e Delphi 685; uma auditoria estrutural das superfícies originais estima Lua em 749 ±35 e Gleam em 731 ±35.

Rust e Delphi estão à frente nas provas de ABI nativa, ownership, lifetime e layouts baixos. Lua e Gleam continuam mais largos no lowering direto da IR tipada, especialmente matemática escalar, macros, records/unions, closures ordinárias e fluxo geral. A prioridade agora é fechar essas lacunas de referência antes de adicionar novas extensões ABI exclusivas.

A família escalar de referência agora cobre `Sqrt`, construção e classificação de NaN, construção de infinito, `Log`, `Exp`, `Tanh`, `Sin` e `Cos` em `f32` e `f64`. Rust usa métodos inerentes e constantes tipadas; Delphi importa `Math` somente quando necessário. `scripts/portable-float-math-family-gate.sh` prova dez chamadas do mesmo fonte Spiral e fecha três identidades, três builds e três execuções.

## Limites honestos

Capturas escalares, strings, arrays e unions recursivas, reutilização, parâmetros, retornos, branches compatíveis e `fptr` não capturante já possuem regressão positiva. O residual callable bounded está completo e permanece parado antes de uma IR geral; packaging de tipos e helpers continua congelado.

O gate `portable-numeric-cast-gate.sh` prova casts inteiros explícitos determinísticos em C, Rust e Delphi. Ponteiros, booleanos, float-to-integer boundary behavior e overflow assinado implementation-defined permanecem fora do contrato. Normalização Unicode geral, algumas bordas numéricas e o packaging completo ainda limitam a paridade ponderada. A união heterogênea de ambientes de closure continua congelada: ela só volta ao plano quando um backend maduro ou fixture de referência exigir exatamente essa superfície.
