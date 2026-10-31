program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap1; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: THeap1; function Invoke(v1: LongInt): TUS0; override; end;
function ClosureCreate0(v0: THeap1): TFun0; forward;
function score_0(v0: TUS0): LongInt; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: THeap1): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function Tf_c0.Invoke(v1: LongInt): TUS0;
var
  v2: Boolean;
begin
  v2 := v1 = 0;
  if v2 then begin
      Result := US0_None;
  end else begin
      Result := US0_Held(v0);
  end;
end;
function ClosureCreate0(v0: THeap1): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: THeap1;
  v2: THeap0;
  v3: LongInt;
  v4: LongInt;
  v5: AnsiString;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v10: Boolean;
  v9: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v1.l0;
          v3 := v1.l1;
          v4 := v2.l0;
          v5 := v2.l1;
          v6 := v4 = 7;
          if v6 then begin
              v7 := v5 = 'hi';
              v8 := v7;
          end else begin
              v8 := False;
          end;
          if v8 then begin
              v9 := v3 = 1;
              v10 := v9;
          end else begin
              v10 := False;
          end;
          if v10 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          Result := 1;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: THeap1;
  v5: TFun0;
  v6: TUS0;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := ClosureCreate0(v4);
  v6 := v5.Invoke(1);
  Result := score_0(v6);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
