program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: Boolean): LongInt; forward;
function method1(v0: Boolean; v1: Boolean): LongInt; forward;
function method2(v0: Boolean): LongInt; forward;
function method0(v0: Boolean): LongInt;
begin
  if v0 then begin
      Result := 1;
  end else begin
      Result := 3;
  end;
end;
function method1(v0: Boolean; v1: Boolean): LongInt;
var
  v2: Boolean;
  v3: Boolean;
begin
  v2 := v0 and v1;
  if v2 then begin
      Result := 1;
  end else begin
      v3 := v0 or v1;
      if v3 then begin
          Result := 2;
      end else begin
          Result := 3;
      end;
  end;
end;
function method2(v0: Boolean): LongInt;
begin
  if v0 then begin
      Result := 1;
  end else begin
      Result := 3;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: Boolean;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: Boolean;
  v6: Boolean;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
  v11: Boolean;
  v10: Boolean;
  v12: Boolean;
begin
  v0 := True;
  v1 := False;
  v2 := method0(v0);
  v3 := method1(v0, v1);
  v4 := method2(v1);
  v5 := v0 = v1;
  v6 := v5 = False;
  v7 := v2 = 1;
  if v7 then begin
      v8 := v3 = 2;
      v9 := v8;
  end else begin
      v9 := False;
  end;
  if v9 then begin
      v10 := v4 = 3;
      v11 := v10;
  end else begin
      v11 := False;
  end;
  v12 := v11 and v6;
  if v12 then begin
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
