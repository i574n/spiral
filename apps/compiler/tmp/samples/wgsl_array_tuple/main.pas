program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: Boolean; end;
  TArray0 = array of TTuple0;
function TupleCreate0(f0: LongInt; f1: Boolean): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
  tmp6: TTuple0;
  v5: LongInt;
  v6: Boolean;
  tmp9: TTuple0;
  v7: LongInt;
  v8: LongInt;
  v9: Boolean;
  tmp13: TTuple0;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
begin
  v0 := 3;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v2 := 4;
  v1[0] := TupleCreate0(v2, True);
  v1[1] := TupleCreate0(7, False);
  v1[2] := TupleCreate0(9, True);
  tmp6 := v1[0];
  v3 := tmp6.f0;
  v4 := tmp6.f1;
  tmp9 := v1[1];
  v5 := tmp9.f0;
  v6 := tmp9.f1;
  v7 := 2;
  tmp13 := v1[v7];
  v8 := tmp13.f0;
  v9 := tmp13.f1;
  if v4 then begin
      v10 := 1;
  end else begin
      v10 := 0;
  end;
  if v6 then begin
      v11 := 10;
  end else begin
      v11 := 0;
  end;
  if v9 then begin
      v12 := 100;
  end else begin
      v12 := 0;
  end;
  v13 := v3 + v5;
  v14 := v13 + v8;
  v15 := v14 + v10;
  v16 := v15 + v11;
  v17 := v16 + v12;
  Result := v17;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
