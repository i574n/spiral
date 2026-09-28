program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralRef_name = ^UnicodeString;
  TSpiralRef_q = ^LongInt;
  TSpiralRef_w = ^LongInt;
  TSpiralStackRefs = record
    name: TSpiralRef_name;
    q: TSpiralRef_q;
    w: TSpiralRef_w;
  end;

procedure SpiralAssignString(var target: UnicodeString; const value: UnicodeString);
var
  nextValue: UnicodeString;
begin
  nextValue := value;
  target := nextValue;
end;

function SpiralMain: LongInt;
var
  a_name_storage: UnicodeString;
  a_q_storage: LongInt;
  a_w_storage: LongInt;
  a, b: TSpiralStackRefs;
begin
  a_name_storage := 'alpha';
  a.name := @a_name_storage;
  a_q_storage := 5;
  a.q := @a_q_storage;
  a_w_storage := 6;
  a.w := @a_w_storage;
  if a.name^ = 'alpha' then begin
    SpiralAssignString(a.name^, 'beta');
    a.q^ := 7;
  end else begin
    SpiralAssignString(a.name^, 'wrong');
    a.q^ := 9;
  end;
  b := a;
  if b.name^ = 'beta' then begin
    b.w^ := 8;
  end else begin
    b.w^ := 11;
  end;
  Result := LongInt(a.q^ + b.w^);
end;

begin
  Halt(SpiralMain);
end.
