program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; c1_1: AnsiString; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; v1: AnsiString; function Invoke(v2: LongInt): TUS0; override; end;
function ClosureCreate0(v0: LongInt; v1: AnsiString): TFun0; forward;
function US0_One(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Both(a0: LongInt; a1: AnsiString): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function Tf_c0.Invoke(v2: LongInt): TUS0;
var
  v3: Boolean;
begin
  v3 := v2 = 0;
  if v3 then begin
      Result := US0_One(0);
  end else begin
      Result := US0_Both(v0, v1);
  end;
end;
function ClosureCreate0(v0: LongInt; v1: AnsiString): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: TFun0;
  v3: TUS0;
  v5: LongInt;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
  v4: LongInt;
begin
  v0 := 3;
  v1 := 'hi';
  v2 := ClosureCreate0(v0, v1);
  v3 := v2.Invoke(1);
  case v3.tag of
      1: begin
          v5 := v3.c1_0;
          v6 := v3.c1_1;
          v7 := v5 = 3;
          if v7 then begin
              v8 := v6 = 'hi';
              v9 := v8;
          end else begin
              v9 := False;
          end;
          if v9 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          v4 := v3.c0_0;
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
