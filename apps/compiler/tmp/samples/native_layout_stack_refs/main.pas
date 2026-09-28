program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralRef_q = ^LongInt;
  TSpiralRef_w = ^LongInt;
  TSpiralStackRefs = record
    q: TSpiralRef_q;
    w: TSpiralRef_w;
  end;

function SpiralMain: LongInt;
var
  a_q_storage: LongInt;
  a_w_storage: LongInt;
  a, b: TSpiralStackRefs;
begin
  a_q_storage := 5;
  a.q := @a_q_storage;
  a_w_storage := 6;
  a.w := @a_w_storage;
  b := a;
  a.q^ := 7;
  b.w^ := 8;
  Result := LongInt(a.q^ + b.w^);
end;

begin
  Halt(SpiralMain);
end.
