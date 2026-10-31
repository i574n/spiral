program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  TFun0 = class
    function Invoke(a0: LongInt): THeap1; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: THeap1; function Invoke(v1: LongInt): THeap1; override; end;
function ClosureCreate0(v0: THeap1): TFun0; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function Tf_c0.Invoke(v1: LongInt): THeap1;
begin
  Result := v0;
end;
function ClosureCreate0(v0: THeap1): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: THeap1;
  v5: TFun0;
  v6: THeap1;
  v7: THeap0;
  v8: LongInt;
  v9: LongInt;
  v10: AnsiString;
  v11: Boolean;
  v13: Boolean;
  v12: Boolean;
  v15: Boolean;
  v14: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := ClosureCreate0(v4);
  v6 := v5.Invoke(1);
  v7 := v6.l0;
  v8 := v6.l1;
  v9 := v7.l0;
  v10 := v7.l1;
  v11 := v9 = 7;
  if v11 then begin
      v12 := v10 = 'hi';
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
      v14 := v8 = 1;
      v15 := v14;
  end else begin
      v15 := False;
  end;
  if v15 then begin
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
