program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TTuple0 = record f0: LongWord; f1: AnsiString; f2: Boolean; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongWord; v1: AnsiString; v2: Boolean; function Invoke(v3: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: LongWord; v1: AnsiString; v2: Boolean): TFun0; forward;
function TupleCreate0(f0: LongWord; f1: AnsiString; f2: Boolean): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function Tf_c0.Invoke(v3: LongInt): TTuple0;
var
  v4: Boolean;
  v5: AnsiString;
begin
  v4 := v3 = 0;
  if v4 then begin
      v5 := 'no';
      Result := TupleCreate0(0, v5, False);
  end else begin
      Result := TupleCreate0(v0, v1, v2);
  end;
end;
function ClosureCreate0(v0: LongWord; v1: AnsiString; v2: Boolean): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1; c.v2 := v2;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongWord;
  v1: AnsiString;
  v2: Boolean;
  v3: TFun0;
  v4: LongWord;
  v5: AnsiString;
  v6: Boolean;
  tmp7: TTuple0;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
  v10: Boolean;
begin
  v0 := 4000000000;
  v1 := 'hi';
  v2 := True;
  v3 := ClosureCreate0(v0, v1, v2);
  tmp7 := v3.Invoke(1);
  v4 := tmp7.f0;
  v5 := tmp7.f1;
  v6 := tmp7.f2;
  v7 := v4 = 4000000000;
  if v7 then begin
      v8 := v5 = 'hi';
      v9 := v8;
  end else begin
      v9 := False;
  end;
  v10 := v9 and v6;
  if v10 then begin
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
