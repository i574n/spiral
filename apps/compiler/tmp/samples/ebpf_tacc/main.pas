program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; end;
function method2(v0: LongInt; v1: LongInt; v2: LongInt): TTuple0; forward;
function method1(v0: LongInt): TTuple0; forward;
function method0(v0: LongInt): LongInt; forward;
function TupleCreate0(f0: LongInt; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method2(v0: LongInt; v1: LongInt; v2: LongInt): TTuple0;
var
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: Boolean;
begin
  while True do begin
      v3 := v0 - 1;
      v4 := v1 + 1;
      v5 := v2 + 2;
      v6 := v3 = 0;
      if v6 then begin
          Result := TupleCreate0(v4, v5);
          Exit;
      end else begin
          v0 := v3;
          v1 := v4;
          v2 := v5;
          Continue;
      end;
  end;
end;
function method1(v0: LongInt): TTuple0;
var
  v1: LongInt;
  v2: LongInt;
  v3: Boolean;
begin
  v1 := 0;
  v2 := 0;
  v3 := v0 = 0;
  if v3 then begin
      Result := TupleCreate0(v1, v2);
  end else begin
      Result := method2(v0, v1, v2);
  end;
end;
function method0(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  tmp2: TTuple0;
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
begin
  tmp2 := method1(v0);
  v1 := tmp2.f0;
  v2 := tmp2.f1;
  v3 := v1 = 4;
  if v3 then begin
      v4 := v2 = 8;
      v5 := v4;
  end else begin
      v5 := False;
  end;
  if v5 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 4;
  Result := method0(v0);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
