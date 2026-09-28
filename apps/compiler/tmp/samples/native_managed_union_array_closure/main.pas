program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TFun0 = class;
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  TClosure0 = class(TFun0)  function Invoke(v0: LongInt): TUS0; override; end;
function ClosureCreate0: TFun0; forward;
function method0(v0: TFun0): TUS0; forward;
function method1(v0: TUS0): LongInt; forward;
function method2(v0: TFun0): TUS0; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function TClosure0.Invoke(v0: LongInt): TUS0;
var
  v1: Boolean;
  v3: TArray0;
  tmp2: TArray0;
  v4: LongInt;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := US0_0;
  end else begin
      tmp2 := nil;
      SetLength(tmp2, 2);
      v3 := tmp2;
      v3[0] := v0;
      v4 := v0 + 1;
      v3[1] := v4;
      Result := US0_1(v3);
  end;
end;
function ClosureCreate0: TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; 
  Result := c;
end;
function method0(v0: TFun0): TUS0;
begin
  Result := v0.Invoke(0);
end;
function method1(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  case v0.tag of
      0: begin // Empty
          Result := 3;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          v2 := LongInt(Length(v1));
          v3 := v1[0];
          v4 := v2 + v3;
          v5 := v1[1];
          v6 := v4 + v5;
          Result := v6;
      end;
  end;
end;
function method2(v0: TFun0): TUS0;
begin
  Result := v0.Invoke(4);
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: TUS0;
  v2: LongInt;
  v3: TUS0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := ClosureCreate0;
  v1 := method0(v0);
  v2 := method1(v1);
  v3 := method2(v0);
  v4 := method1(v3);
  v5 := v2 + v4;
  v6 := v5 + 28;
  Result := v6;
end;
begin
  Halt(SpiralMain);
end.
