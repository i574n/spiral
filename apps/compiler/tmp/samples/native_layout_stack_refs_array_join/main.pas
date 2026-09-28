program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralIntArray = array of LongInt;
  TSpiralRef_items = ^TSpiralIntArray;
  TSpiralRef_q = ^LongInt;
  TSpiralRef_w = ^LongInt;
  TSpiralStackRefs = record
    items: TSpiralRef_items;
    q: TSpiralRef_q;
    w: TSpiralRef_w;
  end;

procedure SpiralAssignIntArray(var target: TSpiralIntArray; const value: TSpiralIntArray);
var
  nextValue: TSpiralIntArray;
begin
  nextValue := Copy(value, 0, Length(value));
  target := nextValue;
end;

function SpiralMain: LongInt;
var
  a_items_storage: TSpiralIntArray;
  a_q_storage: LongInt;
  a_w_storage: LongInt;
  a, b: TSpiralStackRefs;
  next_items_length: LongInt;
begin
  a_items_storage := [1, 2];
  a.items := @a_items_storage;
  a_q_storage := 5;
  a.q := @a_q_storage;
  a_w_storage := 6;
  a.w := @a_w_storage;
  b := a;
  if a.q^ = 5 then begin
    SpiralAssignIntArray(a.items^, [7, 8]);
    next_items_length := Length(b.items^);
    SetLength(b.items^, 3);
    while next_items_length < 3 do begin
      b.items^[next_items_length] := 9;
      Inc(next_items_length);
    end;
  end else begin
    SpiralAssignIntArray(a.items^, [10]);
    next_items_length := Length(b.items^);
    SetLength(b.items^, 2);
    while next_items_length < 2 do begin
      b.items^[next_items_length] := 11;
      Inc(next_items_length);
    end;
  end;
  a.items^[1] := 12;
  a.q^ := Length(b.items^);
  a.w^ := b.items^[2];
  Result := LongInt(a.q^ + a.w^);
end;

begin
  Halt(SpiralMain);
end.
