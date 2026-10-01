program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TUS0 = record tag: LongInt; c1_0: LongInt; c2_0: Boolean; end;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TClosure0 = class(TFun0) v0: TUS0; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: TUS0): TFun0; forward;
function method0(v0: TFun0): LongInt; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_2(a0: Boolean): TUS0;
begin
  Result.tag := 2; Result.c2_0 := a0;
end;
function TClosure0.Invoke(v1: LongInt): LongInt;
var
  v7: LongInt;
  v2: LongInt;
  v3: Boolean;
  v8: LongInt;
begin
  case v0.tag of
      0: begin // Idle
          v7 := 3;
      end;
      1: begin // Hit
          v2 := v0.c1_0;
          v7 := v2;
      end;
      2: begin // Flag
          v3 := v0.c2_0;
          if v3 then begin
              v7 := 11;
          end else begin
              v7 := 5;
          end;
      end;
  end;
  v8 := v7 + v1;
  Result := v8;
end;
function ClosureCreate0(v0: TUS0): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: TFun0): LongInt;
begin
  Result := v0.Invoke(31);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v7: TUS0;
  v3: Boolean;
  v8: TFun0;
begin
  v0 := 2;
  v1 := v0 = 0;
  if v1 then begin
      v7 := US0_0;
  end else begin
      v3 := v0 = 1;
      if v3 then begin
          v7 := US0_1(7);
      end else begin
          v7 := US0_2(True);
      end;
  end;
  v8 := ClosureCreate0(v7);
  Result := method0(v8);
end;
begin
  Halt(SpiralMain);
end.
