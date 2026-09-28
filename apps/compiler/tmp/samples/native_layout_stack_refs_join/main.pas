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
  if a.q^ > 10 then begin
    a.q^ := 9;
  end else begin
    a.q^ := 7;
  end;
  b := a;
  a.w^ := 8;
  Result := LongInt(b.q^ + a.w^);
end;

begin
  Halt(SpiralMain);
end.
