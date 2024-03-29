using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;
using System;
using Object = UnityEngine.Object;
using InspectorPlusVar = UIGridInspector.InspectorPlusVar;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIGrid))]
public class UIGridInspector : Editor {
    public class InspectorPlusVar
    {
        public enum LimitType { None, Max, Min, Range };
        public enum VectorDrawType { None, Direction, Point, PositionHandle, Scale, Rotation };
        public LimitType limitType = LimitType.None;
        public float min = -0.0f;
        public float max = -0.0f;
        public bool progressBar;
        public int iMin = -0;
        public int iMax = -0;
        public bool active = true;
        public string type;
        public string name;
        public string dispName;
        public VectorDrawType vectorDrawType;
        public bool relative = false;
        public bool scale = false;
        public float space = 0.0f;
        public bool[] labelEnabled = new bool[4];
        public string[] label = new string[4];
        public bool[] labelBold = new bool[4];
        public bool[] labelItalic = new bool[4];
        public int[] labelAlign = new int[4];
        public bool[] buttonEnabled = new bool[16];
        public string[] buttonText = new string[16];
        public string[] buttonCallback = new string[16];
        public bool[] buttonCondense = new bool[4];

        public int numSpace = 0;
        public string classType;
        public Vector3 offset = new Vector3(0.5f, 0.5f);
        public bool QuaternionHandle;
	    public bool canWrite = true;
	    public string tooltip;
	    public bool hasTooltip = false;
        public bool toggleStart = false;
        public int toggleSize = 0;
        public int toggleLevel = 0;
        public bool largeTexture;
        public float textureSize;

		public string textFieldDefault;
		public bool textArea;

    public InspectorPlusVar(LimitType _limitType, float _min, float _max, bool _progressBar, int _iMin, int _iMax, bool _active, string _type, string _name, string _dispName,
                        VectorDrawType _vectorDrawType, bool _relative, bool _scale, float _space, bool[] _labelEnabled, string[] _label, bool[] _labelBold, bool[] _labelItalic, int[] _labelAlign, bool[] _buttonEnabled, string[] _buttonText,
                        string[] _buttonCallback, bool[] buttonCondense, int _numSpace, string _classType, Vector3 _offset, bool _QuaternionHandle, bool _canWrite, string _tooltip, bool _hasTooltip,
                        bool _toggleStart, int _toggleSize, int _toggleLevel, bool _largeTexture, float _textureSize, string _textFieldDefault, bool _textArea)
    {
        limitType = _limitType;
        min = _min;
        max = _max;
        progressBar = _progressBar;
        iMax = _iMax;
        iMin = _iMin;
        active = _active;
        type = _type;
        name = _name;
        dispName = _dispName;
        vectorDrawType = _vectorDrawType;
        relative = _relative;
        scale = _scale;
        space = _space;
        labelEnabled = _labelEnabled;
        label = _label;
        labelBold = _labelBold;
        labelItalic = _labelItalic;
        labelAlign = _labelAlign;
        buttonEnabled = _buttonEnabled;
        buttonText = _buttonText;
        buttonCallback = _buttonCallback;
        numSpace = _numSpace;
        classType = _classType;
        offset = _offset;
        QuaternionHandle = _QuaternionHandle;
        canWrite = _canWrite;
        tooltip = _tooltip;
        hasTooltip = _hasTooltip;
        toggleStart = _toggleStart;
        toggleSize = _toggleSize;
        toggleLevel = _toggleLevel;
        largeTexture = _largeTexture;
        textureSize = _textureSize;
		textFieldDefault = _textFieldDefault;
		textArea = _textArea;
    }
    }	
    SerializedObject so;
	SerializedProperty[] properties;
	new string name;
    string dispName;
	Rect tooltipRect;	
	List<InspectorPlusVar> vars;
	void RefreshVars(){for (int i = 0; i < vars.Count; i += 1) properties[i] = so.FindProperty (vars[i].name);}
	void OnEnable ()
	{
        vars = new List<InspectorPlusVar>();
        so = serializedObject;
        vars.Add(new InspectorPlusVar(InspectorPlusVar.LimitType.None,0,0,false,0,0,true,"Arrangement","arrangement","Arrangement",InspectorPlusVar.VectorDrawType.None,false,false,0,new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},new System.Boolean[]{false,false,false,false},new System.Int32[]{0,0,0,0},new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},0,"UIGrid",new Vector3(0.5f,0.5f,0f),false,true,"",false,false,0,0,false,70,"",false));
        vars.Add(new InspectorPlusVar(InspectorPlusVar.LimitType.Min,0,0,false,0,0,true,"Int32","maxPerLine","Max Per Line",InspectorPlusVar.VectorDrawType.None,false,false,0,new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},new System.Boolean[]{false,false,false,false},new System.Int32[]{0,0,0,0},new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},0,"UIGrid",new Vector3(0.5f,0.5f,0f),false,true,"",false,false,0,0,false,70,"",false));
        vars.Add(new InspectorPlusVar(InspectorPlusVar.LimitType.Range,0,800,false,0,0,true,"Single","cellWidth","Cell Width",InspectorPlusVar.VectorDrawType.None,false,false,0,new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},new System.Boolean[]{false,false,false,false},new System.Int32[]{0,0,0,0},new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},0,"UIGrid",new Vector3(0.5f,0.5f,0f),false,true,"",false,false,0,0,false,70,"",false));
        vars.Add(new InspectorPlusVar(InspectorPlusVar.LimitType.Range,0,800,false,0,0,true,"Single","cellHeight","Cell Height",InspectorPlusVar.VectorDrawType.None,false,false,0,new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},new System.Boolean[]{false,false,false,false},new System.Int32[]{0,0,0,0},new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},0,"UIGrid",new Vector3(0.5f,0.5f,0f),false,true,"",false,false,0,0,false,70,"",false));
        vars.Add(new InspectorPlusVar(InspectorPlusVar.LimitType.None,0,0,false,0,0,true,"Boolean","repositionNow","Reposition Now",InspectorPlusVar.VectorDrawType.None,false,false,0,new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},new System.Boolean[]{false,false,false,false},new System.Int32[]{0,0,0,0},new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},0,"UIGrid",new Vector3(0.5f,0.5f,0f),false,true,"",false,false,0,0,false,70,"",false));
        vars.Add(new InspectorPlusVar(InspectorPlusVar.LimitType.None,0,0,false,0,0,true,"Boolean","sorted","Sorted",InspectorPlusVar.VectorDrawType.None,false,false,0,new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},new System.Boolean[]{false,false,false,false},new System.Int32[]{0,0,0,0},new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},0,"UIGrid",new Vector3(0.5f,0.5f,0f),false,true,"",false,false,0,0,false,70,"",false));
        vars.Add(new InspectorPlusVar(InspectorPlusVar.LimitType.None,0,0,false,0,0,true,"Boolean","hideInactive","Hide Inactive",InspectorPlusVar.VectorDrawType.None,false,false,0,new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},new System.Boolean[]{false,false,false,false},new System.Int32[]{0,0,0,0},new System.Boolean[]{false,false,false,false},new System.String[]{"","","",""},new System.String[]{"","","",""},new System.Boolean[]{false,false,false,false},0,"UIGrid",new Vector3(0.5f,0.5f,0f),false,true,"",false,false,0,0,false,70,"",false));	
		int count = vars.Count;
		properties = new SerializedProperty[count];
	}
    
	void ProgressBar (float value, string label)
	{
		GUILayout.Space (3.0f);
		Rect rect = GUILayoutUtility.GetRect (18, 18, "TextField");
		EditorGUI.ProgressBar (rect, value, label);
		GUILayout.Space (3.0f);
	}
	void FloatField(SerializedProperty sp, InspectorPlusVar v)
	{
		if (v.limitType == InspectorPlusVar.LimitType.Min && !sp.hasMultipleDifferentValues)
			sp.floatValue = Mathf.Max (v.min, sp.floatValue);
		else if (v.limitType == InspectorPlusVar.LimitType.Max && !sp.hasMultipleDifferentValues)
			sp.floatValue = Mathf.Min (v.max, sp.floatValue);
		
		if (v.limitType == InspectorPlusVar.LimitType.Range) {
			if (!v.progressBar)
				EditorGUILayout.Slider (sp, v.min, v.max);
			else {
				if (!sp.hasMultipleDifferentValues) {
					sp.floatValue = Mathf.Clamp (sp.floatValue, v.min, v.max);
					ProgressBar ((sp.floatValue - v.min) / v.max, dispName);
				} else
					ProgressBar ((sp.floatValue - v.min) / v.max, dispName);
			}
		}
        else EditorGUILayout.PropertyField(sp, new GUIContent(dispName));
	}
	void IntField(SerializedProperty sp, InspectorPlusVar v)
	{
		if (v.limitType == InspectorPlusVar.LimitType.Min && !sp.hasMultipleDifferentValues)
			sp.intValue = Mathf.Max (v.iMin, sp.intValue);
		else if (v.limitType == InspectorPlusVar.LimitType.Max && !sp.hasMultipleDifferentValues)
			sp.intValue = Mathf.Min (v.iMax, sp.intValue);
		
		if (v.limitType == InspectorPlusVar.LimitType.Range)
		{
			if (!v.progressBar)
			{
                EditorGUI.BeginProperty(new Rect(0.0f, 0.0f, 0.0f, 0.0f), new GUIContent(), sp);
				EditorGUI.BeginChangeCheck ();

                var newValue = EditorGUI.IntSlider(GUILayoutUtility.GetRect(18.0f, 18.0f), new GUIContent(dispName), sp.intValue, v.iMin, v.iMax);
				
				if (EditorGUI.EndChangeCheck ())
					sp.intValue = newValue;
				EditorGUI.EndProperty ();
			}
			else {
				if (!sp.hasMultipleDifferentValues) {
					sp.intValue = Mathf.Clamp (sp.intValue, v.iMin, v.iMax);
					ProgressBar ((float)(sp.intValue - v.iMin) / v.iMax, dispName);
				} else
					ProgressBar ((float)(sp.intValue - v.iMin) / v.iMax, dispName);
			}
		}
        else EditorGUILayout.PropertyField(sp, new GUIContent(dispName));
	}
    int BoolField(SerializedProperty sp, InspectorPlusVar v)
    {
        if (v.toggleStart)
        {
            EditorGUI.BeginProperty(new Rect(0.0f, 0.0f, 0.0f, 0.0f), new GUIContent(), sp);

            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUILayout.Toggle(dispName, sp.boolValue);
            
            if (EditorGUI.EndChangeCheck())
                sp.boolValue = newValue;
            
            EditorGUI.EndProperty();

            if (!sp.boolValue)
                return v.toggleSize;
        }
        else EditorGUILayout.PropertyField(sp, new GUIContent(dispName));

        return 0;
    }
	void PropertyField (SerializedProperty sp, string name)
	{
		if (sp.hasChildren) {
            GUILayout.BeginVertical();
			while (true) {
				if (sp.propertyPath != name && !sp.propertyPath.StartsWith (name + "."))
					break;

				EditorGUI.indentLevel = sp.depth;
                bool child = false;

                if (sp.depth == 0)
                    child = EditorGUILayout.PropertyField(sp, new GUIContent(dispName));
                else
                    child = EditorGUILayout.PropertyField(sp);

				if (!sp.NextVisible (child))
					break;
			}
            EditorGUI.indentLevel = 0;
            GUILayout.EndVertical();
		} else EditorGUILayout.PropertyField(sp, new GUIContent(dispName));
	}
	public override void OnInspectorGUI ()
	{	
		so.Update ();
		RefreshVars();
		
		EditorGUIUtility.LookLikeControls (135.0f, 50.0f);

		for (int i = 0; i < properties.Length; i += 1) 
		{
			InspectorPlusVar v = vars[i];
			
			if (v.active && properties[i] != null) 
			{
				SerializedProperty sp = properties [i];string s = v.type;
							 bool skip = false;
				name = v.name;
                dispName = v.dispName;

				GUI.enabled = v.canWrite;

                GUILayout.BeginHorizontal();

                if (v.toggleLevel != 0)
                   GUILayout.Space(v.toggleLevel * 10.0f);
                
                if (s == typeof(float).Name){
                    FloatField(sp, v);
                    skip = true;
                }
                if (s == typeof(int).Name){
                    IntField(sp, v);
                    skip = true;
                }
                if (s == typeof(bool).Name){
                    i += BoolField(sp, v);
                    skip = true;
                }
                if (!skip)
                    PropertyField(sp, name);
                GUILayout.EndHorizontal();
                GUI.enabled = true;
			}
		}
        so.ApplyModifiedProperties (); 
        //NOTE NOTE NOTE: WATERMARK HERE
        //You are free to remove this
        //START REMOVE HERE
        GUILayout.BeginHorizontal();
        GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        GUILayout.FlexibleSpace();
        GUILayout.Label("Created with");
        GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.6f);
        if (GUILayout.Button("Inspector++"))
            Application.OpenURL("http://forum.unity3d.com/threads/136727-Inspector-Meh-to-WOW-inspectors");
        GUI.color = new Color(1.0f, 1.0f, 1.0f);
		GUILayout.EndHorizontal();
        //END REMOVE HERE
    }
}