# portable_composite

Gate positivo desde o v15. O projeto combina records, tuplas heterogêneas, floats, strings estáticas, unsigned remainder, divisão inteira, chamadas, branches e um pipeline de continuações tipadas.

O aparente timeout do v14 não era explosão de especialização: `package.spiproj` omitira `packages: core-`, deixando operadores residuais sem vínculo enquanto a facade aguardava apenas o canal de código.

Com o pacote corrigido, os quatro resíduos são produzidos em cerca de 0,8-1,0 segundo. C, Rust e Delphi compilam e executam com exit 0; Rust usa warnings como erros. Delphi também cobre a regressão de divisão inteira, que deve emitir `div` em vez de `/`.

Gate reproduzível: `scripts/portable-composite-gate.sh`.
