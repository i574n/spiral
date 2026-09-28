program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TFun0 = class;
  TUS0 = record tag: LongInt; c1_0: AnsiString; c1_1: LongInt; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  TClosure0 = class(TFun0)  function Invoke(v0: LongInt): TUS0; override; end;
function ClosureCreate0: TFun0; forward;
function method0(v0: TFun0): TUS0; forward;
function method1(v0: TFun0): TUS0; forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: AnsiString; a1: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function TClosure0.Invoke(v0: LongInt): TUS0;
var
  v1: Boolean;
  v3: AnsiString;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := US0_0;
  end else begin
      v3 := 'managed';
      Result := US0_1(v3, 32);
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
function method1(v0: TFun0): TUS0;
begin
  Result := v0.Invoke(1);
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: TUS0;
  v7: LongInt;
  v2: AnsiString;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v8: TUS0;
  v14: LongInt;
  v9: AnsiString;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v15: LongInt;
begin
  v0 := ClosureCreate0;
  v1 := method0(v0);
  case v1.tag of
      0: begin // Empty
          v7 := 3;
      end;
      1: begin // Item
          v2 := v1.c1_0;
          v3 := v1.c1_1;
          v4 := LongInt(Length(v2));
          v5 := v4 + v3;
          v7 := v5;
      end;
  end;
  v8 := method1(v0);
  case v8.tag of
      0: begin // Empty
          v14 := 3;
      end;
      1: begin // Item
          v9 := v8.c1_0;
          v10 := v8.c1_1;
          v11 := LongInt(Length(v9));
          v12 := v11 + v10;
          v14 := v12;
      end;
  end;
  v15 := v7 + v14;
  Result := v15;
end;
begin
  Halt(SpiralMain);
end.
