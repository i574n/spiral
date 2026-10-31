program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongWord; f2: Single; end;
function method1(v0: LongInt; v1: LongWord; v2: Single): TTuple0; forward;
function method0(v0: LongInt; v1: LongWord; v2: Single): LongInt; forward;
function TupleCreate0(f0: LongInt; f1: LongWord; f2: Single): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method1(v0: LongInt; v1: LongWord; v2: Single): TTuple0;
begin
  Result := TupleCreate0(v0, v1, v2);
end;
function method0(v0: LongInt; v1: LongWord; v2: Single): LongInt;
var
  v3: LongInt;
  v4: LongWord;
  v5: Single;
  tmp3: TTuple0;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v10: Boolean;
  v9: Boolean;
begin
  tmp3 := method1(v0, v1, v2);
  v3 := tmp3.f0;
  v4 := tmp3.f1;
  v5 := tmp3.f2;
  v6 := v3 = 2;
  if v6 then begin
      v7 := v4 = 3;
      v8 := v7;
  end else begin
      v8 := False;
  end;
  if v8 then begin
      v9 := v5 = 1.5;
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
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongWord;
  v2: Single;
begin
  v0 := 2;
  v1 := 3;
  v2 := 1.5;
  Result := method0(v0, v1, v2);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
