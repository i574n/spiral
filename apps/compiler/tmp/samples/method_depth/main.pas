program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun1 = class;
  TFun1 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TFun0 = class
    function Invoke(a0: LongInt): TFun1; virtual; abstract;
  end;
  Tg_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): TFun1; override; end;
  Th_c1 = class(TFun1) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate1(v0: LongInt): TFun1; forward;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function method0(v0: LongInt): TFun0; forward;
function Th_c1.Invoke(v1: LongInt): LongInt;
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
function ClosureCreate1(v0: LongInt): TFun1;
var c: Th_c1;
begin
  c := Th_c1.Create; c.v0 := v0;
  Result := c;
end;
function Tg_c0.Invoke(v1: LongInt): TFun1;
begin
  Result := ClosureCreate1(v0);
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
  v2: TFun1;
  v3: LongInt;
  v4: Boolean;
begin
  v0 := 7;
  v1 := method0(v0);
  v2 := v1.Invoke(0);
  v3 := v2.Invoke(0);
  v4 := v3 = 7;
  if v4 then begin
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
