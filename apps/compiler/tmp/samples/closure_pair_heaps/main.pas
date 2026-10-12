program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TTuple0 = record f0: THeap0; f1: THeap0; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: THeap0; v1: THeap0; function Invoke(v2: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: THeap0; v1: THeap0): TFun0; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function TupleCreate0(f0: THeap0; f1: THeap0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v2: LongInt): TTuple0;
begin
  Result := TupleCreate0(v0, v1);
end;
function ClosureCreate0(v0: THeap0; v1: THeap0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: THeap0;
  v6: TFun0;
  v7: THeap0;
  v8: THeap0;
  tmp9: TTuple0;
  v9: LongInt;
  v10: AnsiString;
  v11: LongInt;
  v12: AnsiString;
  v13: Boolean;
  v15: Boolean;
  v14: Boolean;
  v17: Boolean;
  v16: Boolean;
  v19: Boolean;
  v18: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  v6 := ClosureCreate0(v2, v5);
  tmp9 := v6.Invoke(1);
  v7 := tmp9.f0;
  v8 := tmp9.f1;
  v9 := v7.l0;
  v10 := v7.l1;
  v11 := v8.l0;
  v12 := v8.l1;
  v13 := v9 = 7;
  if v13 then begin
      v14 := v10 = 'hi';
      v15 := v14;
  end else begin
      v15 := False;
  end;
  if v15 then begin
      v16 := v11 = 4;
      v17 := v16;
  end else begin
      v17 := False;
  end;
  if v17 then begin
      v18 := v12 = 'yo';
      v19 := v18;
  end else begin
      v19 := False;
  end;
  if v19 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
