program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TTuple0 = record f0: THeap0; f1: THeap0; f2: THeap0; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: THeap0; v1: THeap0; v2: THeap0; function Invoke(v3: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: THeap0; v1: THeap0; v2: THeap0): TFun0; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function TupleCreate0(f0: THeap0; f1: THeap0; f2: THeap0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function Tf_c0.Invoke(v3: LongInt): TTuple0;
begin
  Result := TupleCreate0(v0, v1, v2);
end;
function ClosureCreate0(v0: THeap0; v1: THeap0; v2: THeap0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1; c.v2 := v2;
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
  v6: LongInt;
  v7: AnsiString;
  v8: THeap0;
  v9: TFun0;
  v10: THeap0;
  v11: THeap0;
  v12: THeap0;
  tmp13: TTuple0;
  v13: LongInt;
  v14: AnsiString;
  v15: LongInt;
  v16: AnsiString;
  v17: LongInt;
  v18: AnsiString;
  v19: Boolean;
  v21: Boolean;
  v20: Boolean;
  v23: Boolean;
  v22: Boolean;
  v25: Boolean;
  v24: Boolean;
  v27: Boolean;
  v26: Boolean;
  v29: Boolean;
  v28: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  v6 := 9;
  v7 := 'ok';
  v8 := HeapCreate0(v6, v7);
  v9 := ClosureCreate0(v2, v5, v8);
  tmp13 := v9.Invoke(1);
  v10 := tmp13.f0;
  v11 := tmp13.f1;
  v12 := tmp13.f2;
  v13 := v10.l0;
  v14 := v10.l1;
  v15 := v11.l0;
  v16 := v11.l1;
  v17 := v12.l0;
  v18 := v12.l1;
  v19 := v13 = 7;
  if v19 then begin
      v20 := v14 = 'hi';
      v21 := v20;
  end else begin
      v21 := False;
  end;
  if v21 then begin
      v22 := v15 = 4;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := v16 = 'yo';
      v25 := v24;
  end else begin
      v25 := False;
  end;
  if v25 then begin
      v26 := v17 = 9;
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
      v28 := v18 = 'ok';
      v29 := v28;
  end else begin
      v29 := False;
  end;
  if v29 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
