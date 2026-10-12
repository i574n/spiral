program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TUS0 = record tag: LongInt; c1_0: TFun0; c1_1: LongInt; end;
  Tadd_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function score_0(v0: TUS0): LongInt; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Call(a0: TFun0; a1: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function Tadd_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tadd_c0;
begin
  c := Tadd_c0.Create; c.v0 := v0;
  Result := c;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: TFun0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v1.Invoke(0);
          v4 := v3 + v2;
          v5 := v4 = 7;
          if v5 then begin
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
  v1: LongInt;
  v2: Boolean;
  v6: TUS0;
  v3: TFun0;
begin
  v0 := 3;
  v1 := 4;
  v2 := True;
  if v2 then begin
      v3 := ClosureCreate0(v0);
      v6 := US0_Call(v3, v1);
  end else begin
      v6 := US0_None;
  end;
  Result := score_0(v6);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
