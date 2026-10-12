program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tg_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function method0(v0: LongInt): TFun0; forward;
function Tg_c0.Invoke(v1: LongInt): LongInt;
var
  v2: Boolean;
  v3: LongInt;
begin
  v2 := v0 = 0;
  if v2 then begin
      Result := 0;
  end else begin
      v3 := v1 + v0;
      Result := v3;
  end;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tg_c0;
begin
  c := Tg_c0.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: LongInt): TFun0;
begin
  Result := ClosureCreate0(v0);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: LongInt;
  v3: Boolean;
begin
  v0 := 7;
  v1 := method0(v0);
  v2 := v1.Invoke(0);
  v3 := v2 = 7;
  if v3 then begin
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
